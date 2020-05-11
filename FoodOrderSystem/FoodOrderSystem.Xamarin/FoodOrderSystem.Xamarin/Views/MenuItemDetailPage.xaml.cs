using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FoodOrderSystem.Xamarin.Models;
using FoodOrderSystem.Xamarin.ViewModels;

namespace FoodOrderSystem.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuItemDetailPage : ContentPage
    {
        MenuItemDetailViewModel viewModel;
        
        public MenuItemDetailPage(MenuItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;


        }

        public MenuItem item = new MenuItem
        {
            ItemName = "Item Name",     // Placeholder
            Price = (float)4.99
        };

        public MenuItemDetailPage()
        {
            InitializeComponent();
            
            viewModel = new MenuItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        private void AddToCart_Clicked(object sender, EventArgs e)
        {
            //    OrderItem orderItem = new OrderItem()
            //    {
            //        Id = Guid.NewGuid(),
            //        OrderId = App.userCart.Id,
            //        MenuItemId = item.Id
            //};

            ShoppingCartManager.Add(App.userCart, viewModel.MenuItem);
            //App.userCart.Add(viewModel.MenuItem);
            DisplayAlert("Alert", "Added to Cart. There are " + App.userCart.Items.Count + " item(s) in your cart", "Ok");
        }
    }
}