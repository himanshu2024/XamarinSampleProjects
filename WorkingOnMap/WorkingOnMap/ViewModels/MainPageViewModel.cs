using System;
using System.Windows.Input;
using WorkingOnMap.Views;
using Xamarin.Forms;

namespace WorkingOnMap.ViewModels
{
    public class MainPageViewModel
    {
        private INavigation _navigation;
        public ICommand FormsMapClick { get; set; }
        public MainPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            FormsMapClick = new Command(FormsMapCommand);
        }

        private void FormsMapCommand()
        {
            _navigation.PushAsync(new FormsMapPage());
        }
    }
}
