using System;
using System.Collections.Generic;
using WorkingOnDatabase.Database;
using WorkingOnDatabase.Database.Models;
using Xamarin.Forms;

namespace WorkingOnDatabase.ViewModels
{
    public class AddEditViewModel : BaseViewModel
    {
        private IDataStore<Item> dataStore = App.repo;
        private Item item;

        private string _title;
        public string Title { get { return _title; } set => SetProperty(ref _title, value); }
        private string _textValue;
        public string TextValue { get { return _textValue; } set => SetProperty(ref _textValue, value); }
        private string _detailValue;
        public string DetailValue { get { return _detailValue; } set => SetProperty(ref _detailValue, value); }

        private int _categorySelectIndex = -1;
        public int CategorySelectIndex { get { return _categorySelectIndex; } set => SetProperty(ref _categorySelectIndex, value); }

        private List<string> _categoryList;
        public List<string> CategoryList { get { return _categoryList; } set => SetProperty(ref _categoryList, value); }

        public Command SaveCommand { get; set; }

        public AddEditViewModel(Page page, INavigation navigation)
        {
            _page = page;
            _navigation = navigation;
            SaveCommand = new Command(SaveClick);

        }

        public void SetData(Item item)
        {
            this.item = item;
            CategoryList = new List<string> { "Shopping", "Work", "Private" };

            if (item == null)
            {
                CategorySelectIndex = 0;
            }
            else
            {
                TextValue = item.Text;
                DetailValue = item.Description;
                SetSelectedIndex(item.Category);
            }
        }

        private async void SaveClick()
        {
            bool hasUpdated = false;
            if(!string.IsNullOrEmpty(TextValue))
            {
                if(!string.IsNullOrEmpty(DetailValue))
                {
                    if (item == null)
                    {
                        Item item = new Item
                        {
                            Id = Guid.NewGuid().ToString(),
                            Text = TextValue,
                            Description = DetailValue,
                            Category = GetSelectedCat(CategorySelectIndex)
                        };
                        hasUpdated = await dataStore.AddItemAsync(item);
                    }
                    else
                    {
                        item.Text = TextValue;
                        item.Description = DetailValue;
                        item.Category = GetSelectedCat(CategorySelectIndex);

                        hasUpdated = await dataStore.UpdateItemAsync(item);

                    }
                }
            }

            if (hasUpdated)
                await _navigation.PopToRootAsync();
            else
                await _page.DisplayAlert("Error", "Please fill all details", "Ok");
        }

        private void SetSelectedIndex(ItemCategory category)
        {
            switch(category)
            {
                case ItemCategory.Private:
                    CategorySelectIndex = 2;
                    break;
                case ItemCategory.Shopping:
                    CategorySelectIndex = 0;

                    break;
                case ItemCategory.Work:
                    CategorySelectIndex = 1;

                    break;
            }
        }

        private ItemCategory GetSelectedCat(int category)
        {
            switch (category)
            {
                case 2:
                    return ItemCategory.Private;
                    break;
                case 0:
                    return ItemCategory.Shopping;

                    break;
                case 1:
                    return ItemCategory.Work;

                    break;
                default:
                    return ItemCategory.Private;
            }
        }
    }


}
