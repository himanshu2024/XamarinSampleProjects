using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace CustomBindableProperty.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public Command ButtonCommand { get; set; }

        public Command<string> CustomButtonCommand { get; set; }
        public MainPageViewModel(Page page, INavigation navigation)
        {
            _page = page;
            _navigation = navigation;

            ButtonCommand = new Command(ButtonClicked);
            CustomButtonCommand = new Command<string>(CustomButtonClicked);
        }

        private void CustomButtonClicked(string param)
        {
            _page.DisplayAlert("Clicked", "Custom Button "+param, "Ok");
        }

        private void ButtonClicked()
        {
            _navigation.PushAsync(new Views.MyListPage());
        }
    }
}
