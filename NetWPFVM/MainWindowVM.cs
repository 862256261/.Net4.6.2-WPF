using CommunityToolkit.Mvvm.Input;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetWPFVM
{
    public class MainWindowVM : BaseViewModel
    {
        public MainWindowVM()
        {
            ClikeShowMsgCommand = new RelayCommand(p => ShowMsg());
            LoadingCommand = new RelayCommand(p => LoadingData());
        }

        private void LoadingData()
        {
            OnShowProcess?.Invoke(async (object sender, DialogOpenedEventArgs eventArgs) =>
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(2000);
                }).ContinueWith((t, _) => eventArgs.Session.Close(), null, TaskScheduler.FromCurrentSynchronizationContext());
            });
        }

        public RelayCommand ClikeShowMsgCommand { get; set; }
        public RelayCommand LoadingCommand { get; set; }
        private void ShowMsg()
        {
            OnShowMessage?.Invoke("一个测试消息");
        }
    }
}
