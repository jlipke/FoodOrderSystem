using FoodOrderSystem.Xamarin.Models;
using FoodOrderSystem.Xamarin.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderSystem.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShoppingCartPage : ContentPage
    {
        ShoppingCartViewModel viewModel;
        MenuItemsViewModel menuVM;
        public ShoppingCartPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ShoppingCartViewModel();
            BindingContext = menuVM = new MenuItemsViewModel();

            lblSubtotal.Text = App.userCart.Subtotal.ToString();

        }

        
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as MenuItem;
            if (item == null)
                return;

            await Navigation.PushAsync(new UserCartItemDetailPage(new UserCartItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.LoadItemsCommand.Execute(null);
            ItemsListView.ItemsSource = viewModel.CartItems;

            lblSubtotal.Text = App.userCart.Subtotal.ToString();
            lblTax.Text = App.userCart.TaxCost.ToString();
            lblTotal.Text = App.userCart.Total.ToString();
            

        }

        private void CompleteOrder_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddressSelectPage());
        }
    }
}