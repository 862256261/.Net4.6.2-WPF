using CommunityToolkit.Mvvm.ComponentModel;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NetWPFVM
{
    public class BaseViewModel : ObservableObject, INotifyPropertyChanged
    {
        public BaseViewModel() { }
        public Action<object> OnShowMessage { get; set; }
        public Action<DialogOpenedEventHandler> OnShowProcess { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
          => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
