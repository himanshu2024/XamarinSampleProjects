using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WorkingOnDatabase.Database;
using WorkingOnDatabase.Database.Models;
using WorkingOnDatabase.Views;
using Xamarin.Forms;

namespace WorkingOnDatabase.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private IDataStore<Item> dataStore = App.repo;

        private ObservableCollection<Item> _ItemList;
        public ObservableCollection<Item> ItemList { get { return _ItemList; } set => SetProperty(ref _ItemList, value); }

        public ICommand AddCommand { get; set; }
        public Command<Item> ItemClicked { get; set; }

        public MainViewModel(Page page, INavigation navigation)
        {
            _page = page;
            _navigation = navigation;
            AddCommand = new Command(AddClick);
            ItemClicked = new Command<Item>(ItemTapped);
        }

        private void ItemTapped(Item obj)
        {
            _navigation.PushAsync(new AddEditPage(obj));
        }

        private void AddClick()
        {
            _navigation.PushAsync(new AddEditPage());
        }

        public async void SetData()
        {
            var list = await dataStore.GetItemsAsync();
            ItemList = new ObservableCollection<Item>(list);
        }

    }
}
