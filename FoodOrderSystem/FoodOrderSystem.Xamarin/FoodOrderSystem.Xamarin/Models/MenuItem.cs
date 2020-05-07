using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderSystem.Xamarin
{
    public class MenuItem
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; }
        public float Price { get; set; }
    }
}