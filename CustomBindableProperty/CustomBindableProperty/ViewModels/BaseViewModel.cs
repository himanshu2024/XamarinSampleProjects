using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace CustomBindableProperty.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected Page _page;
        protected INavigation _navigation;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
