using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderSystem.Xamarin.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid MenuItemId { get; set; }
    }
}
