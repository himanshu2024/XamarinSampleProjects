using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomBindableProperty.ViewModels;
using Xamarin.Forms;

namespace CustomBindableProperty.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        //public MainPageViewModel VM => ((MainPageViewModel)BindingContext);
        public MainPage()
        {
            InitializeComponent();
            MainPageViewModel pageViewModel = new MainPageViewModel(this, Navigation);
            BindingContext = pageViewModel;
        }
    }
}
