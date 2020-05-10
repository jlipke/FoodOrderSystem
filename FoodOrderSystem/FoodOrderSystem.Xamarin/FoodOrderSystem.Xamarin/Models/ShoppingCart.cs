using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderSystem.Xamarin.Models
{
    public class ShoppingCart
    {
        public List<MenuItem> Items { get; set; }
        public double Subtotal { get; set; }
        public double TaxCost { get; set; }
        public double Total { get; set; }

        public ShoppingCart()
        {
            Items = new List<MenuItem>();
        }

        public void Add(MenuItem menuitem)
        {
            Items.Add(menuitem);
            Subtotal += Math.Round((Convert.ToDouble(menuitem.Price)), 2);
            TaxCost = Math.Round((Subtotal * 0.055), 2);
            Total = Math.Round((Subtotal + TaxCost), 2);
        }

        public void Remove(MenuItem menuitem)
        {
            Items.Remove(menuitem);
            Subtotal -= Math.Round((Convert.ToDouble(menuitem.Price)), 2);
            TaxCost = Math.Round((Subtotal * 0.055), 2);
            Total = Math.Round((Subtotal + TaxCost), 2);
        }


        public void ClearCart()
        {
            Items = new List<MenuItem>();
            Total = 0;
            Subtotal = 0;
            TaxCost = 0;
        }
    }
}
