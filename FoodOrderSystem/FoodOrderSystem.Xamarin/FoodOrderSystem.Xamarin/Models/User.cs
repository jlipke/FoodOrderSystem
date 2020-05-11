using System;
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
    }
}
