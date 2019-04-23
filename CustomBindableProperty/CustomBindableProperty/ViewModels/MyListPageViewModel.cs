using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CustomBindableProperty.Models;
using Xamarin.Forms;

namespace CustomBindableProperty.ViewModels
{
    public class MyListPageViewModel : BaseViewModel
    {
        public ObservableCollection<MyListModel> ListModels { get; set; }
        public Command<MyListModel> ItemTapped { get; set; }

        public MyListPageViewModel(Page page, INavigation navigation)
        {
            _page = page;
            _navigation = navigation;
            ListModels = new ObservableCollection<MyListModel>(new MyListModel().GetMyLists());
            ItemTapped = new Command<MyListModel>(ItemClicked);
        }

        private void ItemClicked(MyListModel model)
        {
            _page.DisplayAlert("Clicked Alert", "Name = " + model.Name, "Ok");
            Debug.WriteLine("Clicked on " + model.Name);
        }
    }
}
