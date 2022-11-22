using ADSB_Image_Recommender.Models;
using ADSB_Image_Recommender.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ADSB_Image_Recommender.ViewModels
{
    public class FormPageViewModel : BaseViewModel
    {
        private Item _selectedItem;

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

        public IList<FormContents> ImageTypeList { get; set; }

        public IList<FormContents> ImageTopicList { get; set; }


        public FormPageViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);

            try
            {
                ImageTypeList = new ObservableCollection<FormContents>();
                ImageTypeList.Add(new FormContents { ImageType = "Gif" });
                ImageTypeList.Add(new FormContents { ImageType = "Static" });
            }
            catch (Exception ex)
            {

            }
            try
            {
                ImageTopicList = new ObservableCollection<FormContents>();
                ImageTopicList.Add(new FormContents { ImageTopic = "Animals" });
                ImageTopicList.Add(new FormContents { ImageTopic = "Food" });
                ImageTopicList.Add(new FormContents { ImageTopic = "Sports" });
                ImageTopicList.Add(new FormContents { ImageTopic = "Nature" });
            }
            catch (Exception ex)
            {

            }


        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}