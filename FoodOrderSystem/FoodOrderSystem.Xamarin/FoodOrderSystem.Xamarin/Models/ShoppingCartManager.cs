using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderSystem.Xamarin.Models
{
    public static class ShoppingCartManager
    {
        public static void Add(ShoppingCart cart, MenuItem menuitem)
        {
            cart.Add(menuitem);
        }

        public static void Remove(ShoppingCart cart, MenuItem menuitem)
        {
            cart.Remove(menuitem);
        }

        

        
    }
}
