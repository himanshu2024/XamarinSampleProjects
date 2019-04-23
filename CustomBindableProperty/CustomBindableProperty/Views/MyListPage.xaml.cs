using System;
using System.Collections.Generic;
using CustomBindableProperty.ViewModels;
using Xamarin.Forms;

namespace CustomBindableProperty.Views
{
    public partial class MyListPage : ContentPage
    {
        public MyListPage()
        {
            InitializeComponent();
            MyListPageViewModel pageViewModel = new MyListPageViewModel(this, Navigation);
            BindingContext = pageViewModel;
        }
    }
}
