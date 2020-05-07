using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using FoodOrderSystem.Xamarin.Models;
using FoodOrderSystem.Xamarin.Views;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FoodOrderSystem.Xamarin.ViewModels
{
    public class MenuItemsViewModel : BaseViewModel
    {
        public ObservableCollection<MenuItem> MenuItems { get; set; }
        public Command LoadItemsCommand { get; set; }
        public List<MenuItem> ListMenuItems;
        public MenuItemsViewModel()
        {
            Title = "Menu";
            MenuItems = new ObservableCollection<MenuItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            
        }

        public async Task<List<MenuItem>> LoadFromAPI()
        {
            // Create apiUrl to distinguish between Android and iOS users
            string apiUrl = null;
            if (Device.RuntimePlatform == Device.Android)
                apiUrl = "http://10.0.2.2:62568/api/MenuItem";
            else if (Device.RuntimePlatform == Device.iOS)
                apiUrl = "http://localhost:62568/api/MenuItem";
           

            // Create HttpClient
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(apiUrl);
            var items = JsonConvert.DeserializeObject<List<MenuItem>>(response);
            
            // Populate the List of Items
            return items;


        }

        async Task ExecuteLoadItemsCommand()    // Will load the items in this section
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                MenuItems.Clear();
                ListMenuItems = await LoadFromAPI();
                var menuitems = ListMenuItems; /*await DataStore.GetItemsAsync(true); */   // This will be where I add the list of menuItems from the api
                foreach (var menuitem in menuitems)
                {
                    MenuItems.Add(menuitem);
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
    }
}