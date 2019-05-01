using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomBindableProperty.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomBindableProperty.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyTabbedPage : TabbedPage
    {
        public MyTabbedPage()
        {
            InitializeComponent();
            MyTabbedPageViewModel pageViewModel = new MyTabbedPageViewModel();
            BindingContext = pageViewModel;
        }
    }
}
