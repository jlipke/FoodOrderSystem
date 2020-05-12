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
    public class PaymethodSelectViewModel : BaseViewModel
    {
        
        public ObservableCollection<UserPayment> PaymentItems { get; set; }

        public Command LoadPaymethodCommand { get; set; }
        
        public List<UserPayment> ListPaymentItems { get; set; }



        public PaymethodSelectViewModel()
        {
            Title = "PayMethod";
            PaymentItems = new ObservableCollection<UserPayment>();

            LoadPaymethodCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }

       

        async Task ExecuteLoadItemsCommand()    // Will load the items in this section
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                    
                    PaymentItems.Clear();   // Get Paymethods from the Logged in user
                    ListPaymentItems = App.LoggedInUser.Payments;
                    var paymentitems = ListPaymentItems;    
                    foreach (var paymethod in paymentitems)
                    {
                        PaymentItems.Add(paymethod);
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