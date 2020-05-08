using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderSystem.Xamarin.Models
{
    public enum MenuItemType
    {
        Menu,
        ShoppingCart,
        Login,
        AccountDetails
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
