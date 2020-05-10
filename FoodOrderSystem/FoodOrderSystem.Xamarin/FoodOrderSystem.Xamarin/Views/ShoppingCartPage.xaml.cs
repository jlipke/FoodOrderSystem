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
        }

        async void CreateAccountClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateAccountPage());
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as MenuItem;
            if (item == null)
                return;

            await Navigation.PushAsync(new MenuItemDetailPage(new MenuItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.LoadItemsCommand.Execute(null);
            ItemsListView.ItemsSource = viewModel.CartItems;



        }

        private void Button_Clicked(object sender, EventArgs e)
        {

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