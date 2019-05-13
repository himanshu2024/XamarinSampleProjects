using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingOnMap.ViewModels;
using Xamarin.Forms;

namespace WorkingOnMap.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MainPageViewModel pageViewModel = new MainPageViewModel(Navigation);
            BindingContext = pageViewModel;
        }
    }
}
