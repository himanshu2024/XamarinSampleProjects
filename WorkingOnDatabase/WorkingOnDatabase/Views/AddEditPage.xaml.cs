using System;
using System.Collections.Generic;
using WorkingOnDatabase.Database.Models;
using WorkingOnDatabase.ViewModels;
using Xamarin.Forms;

namespace WorkingOnDatabase.Views
{
    public partial class AddEditPage : ContentPage
    {
        private AddEditViewModel addEditViewModel;
        private Item item = null;

        public AddEditPage()
        {
            InitializeComponent();
            addEditViewModel = new AddEditViewModel(this, Navigation);
            BindingContext = addEditViewModel;
        }

        public AddEditPage(Item item)
        {
            InitializeComponent();
            addEditViewModel = new AddEditViewModel(this, Navigation);
            BindingContext = addEditViewModel;
            this.item = item;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            addEditViewModel.SetData(item);
        }
    }
}
