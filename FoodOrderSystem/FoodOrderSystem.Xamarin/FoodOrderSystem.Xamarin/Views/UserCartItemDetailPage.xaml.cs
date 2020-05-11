using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FoodOrderSystem.Xamarin.Models;
using FoodOrderSystem.Xamarin.ViewModels;

namespace FoodOrderSystem.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserCartItemDetailPage : ContentPage
    {
        UserCartItemDetailViewModel viewModel;
        
        public UserCartItemDetailPage(UserCartItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;


        }

        public MenuItem item = new MenuItem
        {
            ItemName = "Item Name",     // Placeholder
            Price = (float)4.99
        };

        public UserCartItemDetailPage()
        {
            InitializeComponent();
            
            viewModel = new UserCartItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        private void AddToCart_Clicked(object sender, EventArgs e)
        {
        
            App.userCart.Add(viewModel.MenuItem);
            DisplayAlert("Alert", "Added to Cart. There are " + App.userCart.Items.Count + " item(s) in your cart", "Ok");
            Navigation.PopAsync();
        }

        async void DeleteFromCart_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayAlert("Alert", "Are you sure you would like to delete " + viewModel.MenuItem.ItemName + " from your cart?", "Yes", "No");
            if (action == true)
            {
                await DisplayAlert("Alert", "Deleted from Cart", "Ok");
                App.userCart.Remove(viewModel.MenuItem);
                await Navigation.PopAsync();
            }
            else
            {
                return;
            }
            
        }
    }
}