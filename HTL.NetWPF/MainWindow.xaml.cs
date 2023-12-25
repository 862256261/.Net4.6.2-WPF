using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using NetWPFVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HTL.NetWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowVM windowVM = new MainWindowVM();
            windowVM.OnShowMessage += ShowMsg;
            windowVM.OnShowProcess += ShowProgress;
            DataContext = windowVM;
        }
        public async void ShowMsg(object msg)
        {
            var dialog = new ShowMessageControl();
            dialog.Message = msg.ToString();
            if (!DialogHost.IsDialogOpen("GlobalHost"))
            {
                await DialogHost.Show(dialog, "GlobalHost");
            }
        }
        public async void ShowProgress(DialogOpenedEventHandler dialogOpenedEventHandler)
        {
            var progressDialog = new ProgressControl();
            if (!DialogHost.IsDialogOpen("GlobalHost"))
            {
                var result = await DialogHost.Show(progressDialog, "GlobalHost", (object sender, DialogOpenedEventArgs eventArgs) =>
                  {
                      dialogOpenedEventHandler(sender, eventArgs);
                  });
                ShowMsg("加载完成");
            }
        }
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // ShowMsg("测试提示");
        }
    }
}
