using FoodOrderSystem.Xamarin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace FoodOrderSystem.Xamarin.ViewModels
{
    public class ShoppingCartViewModel : BaseViewModel
    {
        public ObservableCollection<MenuItem> CartItems { get; set; }
        public Command LoadItemsCommand { get; set; }
        public List<MenuItem> ListCartItems { get; set; }

        public ShoppingCartViewModel()
        {
            Title = "Shopping Cart";
            CartItems = new ObservableCollection<MenuItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());


        }

        private async Task<User> LoadFromAPI(string email, string password)
        {
            try
            {
                // Create apiUrl to distinguish between Android and iOS users
                // This was used to connect to localhost api. Android needed a redirect with Jexus Manager because the 
                // Android Emulator doesn't understand 'localhost' and needs to be told '127.0.0.1'

                //string apiUrl = null;
                //if (Device.RuntimePlatform == Device.Android)
                //    apiUrl = "http://10.0.2.2:62568/api/Login?Email=" + email + "&Password=" + password;
                //else if (Device.RuntimePlatform == Device.iOS)
                //    apiUrl = "http://localhost:62568/api/Login?Email=" + email + "&Password=" + password;


                // Create HttpClient

                HttpClient client = new HttpClient();
                //client.BaseAddress = new Uri(apiUrl);


                // Http Get

                var response = await client.GetStringAsync("http://jwfoodordersystem.azurewebsites.net/api/Login?Email=" + email + "&Password=" + password);
                var item = JsonConvert.DeserializeObject<User>(response);

                // Return user
                return item;
            }
            catch (Exception ex)
            {

                throw ex;
            }

           

        }

        async Task ExecuteLoadItemsCommand()    // Will load the items in this section
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                
                CartItems.Clear();
                ListCartItems = App.userCart;
                var cartitems = ListCartItems;    // Add the list of menuItems from the userCart
                foreach (var menuitem in cartitems)
                {
                    CartItems.Add(menuitem);
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

        public async Task<User> LogIn(string email, string password)    // Log in
        {
            if (IsBusy)
                return null;

            IsBusy = true;

            try
            {
               
                User loggedinUser = await LoadFromAPI(email, password);

                return loggedinUser;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}