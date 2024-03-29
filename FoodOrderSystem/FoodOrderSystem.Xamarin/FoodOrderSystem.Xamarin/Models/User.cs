﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderSystem.Xamarin.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<UserAddress> Addresses { get; set; }
        public List<UserPayment> Payments { get; set; }

        public Guid SelectedAddressId { get; set; }
        public Guid SelectedPaymentId { get; set; }
        public List<UserAddress> SelectedAddress { get; set; }  // It's in a list to be able to add it to a ListView
        public List<UserPayment> SelectedPaymethod { get; set; }

        public User()
        {
            SelectedAddress = new List<UserAddress>();
            SelectedPaymethod = new List<UserPayment>();
        }
    }

    
}
