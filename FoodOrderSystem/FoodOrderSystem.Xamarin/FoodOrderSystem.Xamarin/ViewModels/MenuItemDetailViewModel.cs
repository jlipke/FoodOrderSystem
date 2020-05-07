using System;

using FoodOrderSystem.Xamarin.Models;

namespace FoodOrderSystem.Xamarin.ViewModels
{
    public class MenuItemDetailViewModel : BaseViewModel
    {
        public MenuItem MenuItem { get; set; }
        public MenuItemDetailViewModel(MenuItem item = null)
        {
            Title = item?.ItemName;
            MenuItem = item;
        }
    }
}
