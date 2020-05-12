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
    public class SubmitOrderViewModel : BaseViewModel
    {
        public ObservableCollection<UserAddress> AddressItems { get; set; }

        public Command LoadAddressCommand { get; set; }

        public List<UserAddress> ListAddressItems { get; set; }



        public SubmitOrderViewModel()
        {
            Title = "Address";
            AddressItems = new ObservableCollection<UserAddress>();

            LoadAddressCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }

       

        async Task ExecuteLoadItemsCommand()    // Will load the items in this section
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {

                    AddressItems.Clear();
                    ListAddressItems = App.LoggedInUser.Addresses;
                    var addressitems = ListAddressItems;    // Add the list of menuItems from the userCart
                    foreach (var address in addressitems)
                    {
                        AddressItems.Add(address);
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