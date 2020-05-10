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
        
        //private async void ShoppingCartClicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if(txtEmail.Text == null || txtPassword.Text == null)
        //        {
        //            await DisplayAlert("Alert", "Please fill all of your information", "Ok");
        //        }
        //        else
        //        {
        //            string email = txtEmail.Text;
        //            string password = txtPassword.Text;

        //            App.LoggedInUser = await viewModel.LogIn(email, password);

        //            if (App.LoggedInUser != null)
        //            {
        //                App.IsUserLoggedIn = true;
        //                await DisplayAlert("ShoppingCart Successful", "Welcome, " + App.LoggedInUser.FirstName, "Ok");
        //                await Navigation.PopAsync();


        //            }

        //            else
        //            {
        //                await DisplayAlert("Alert", "Incorrect ShoppingCart information ", "Ok");
        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
    }
}