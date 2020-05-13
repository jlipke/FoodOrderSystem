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
        //public ObservableCollection<UserAddress> AddressItems { get; set; }
        //public ObservableCollection<UserPayment> PaymentItems { get; set; }


        //public List<UserAddress> ListAddressItems { get; set; }
        //public List<UserPayment> ListPaymentItems { get; set; }




        public SubmitOrderViewModel()
        {

            //AddressItems = new ObservableCollection<UserAddress>();
            //PaymentItems = new ObservableCollection<UserPayment>();

            //LoadAddressPaymentsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }

        public Order ConvertShoppingCartToOrder(ShoppingCart cart, User user)
        {
            Order order = new Order();
            order.Id = Guid.NewGuid();
            order.UserId = user.Id;
            order.AddressId = user.SelectedAddressId;
            order.PaymentId = user.SelectedPaymentId;
            order.Date = DateTime.Now;

            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (MenuItem item in cart.Items)
            {
                OrderItem orderitem = new OrderItem();
                orderitem.Id = Guid.NewGuid();                  // Loop through Cart items and add them to the List of orderitems
                orderitem.MenuItemId = item.Id;
                //orderitem.OrderId = order.Id;
                orderItems.Add(orderitem);
            }

            order.OrderItems = orderItems;

            return order;

        }

        public bool success = false;

        public async Task SendOrder(Order order)    // Will Send the order
        {
            if (IsBusy)
                return;

            IsBusy = true;


            try
            {

                // Create HttpClient

                HttpClient client = new HttpClient();

                // Http Post

                try
                {
                    //Order item = new Order();
                    var response = await client.PostAsJsonAsync("http://jwfoodordersystem.azurewebsites.net/api/Order/", order);
                    response.EnsureSuccessStatusCode();
                    success = response.IsSuccessStatusCode;

                }
                catch (Exception ex)
                {

                    throw ex;
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }


            finally
            {
                IsBusy = false;
            }


        }




    }
}