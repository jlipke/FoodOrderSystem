using FoodOrderSystem.Xamarin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

       

        async Task ExecuteLoadItemsCommand()    // Will load the items in this section
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                
                CartItems.Clear();
                ListCartItems = App.userCart.Items;
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

        
    }
}