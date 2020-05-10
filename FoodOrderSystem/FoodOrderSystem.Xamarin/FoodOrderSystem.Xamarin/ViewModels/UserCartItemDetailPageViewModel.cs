using System;

using FoodOrderSystem.Xamarin.Models;

namespace FoodOrderSystem.Xamarin.ViewModels
{
    public class UserCartItemDetailViewModel : BaseViewModel
    {
        public MenuItem MenuItem { get; set; }
        public UserCartItemDetailViewModel(MenuItem item = null)
        {
            Title = item?.ItemName;
            MenuItem = item;
        }
    }
}
