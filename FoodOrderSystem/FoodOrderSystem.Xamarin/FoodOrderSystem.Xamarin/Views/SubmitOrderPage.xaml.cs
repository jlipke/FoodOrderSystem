using FoodOrderSystem.Xamarin.Models;
using FoodOrderSystem.Xamarin.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderSystem.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubmitOrderPage : ContentPage
    {
        SubmitOrderViewModel viewModel;
        MenuItemsViewModel menuVM;
        public SubmitOrderPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new SubmitOrderViewModel();
            BindingContext = menuVM = new MenuItemsViewModel();
            

        }

        
        //async void OnAddressSelected(object sender, SelectedItemChangedEventArgs args)
        //{
        //    var item = args.SelectedItem as UserAddress;
        //    if (item == null)
        //        return;

        //    item.Id = App.LoggedInUser.SelectedAddressId;

        //    var action = await DisplayAlert("Alert", "Would you like to change the selected Address?", "Yes", "No");
        //    if (action)
        //    {
        //        App.LoggedInUser.SelectedAddress.Clear();
        //        await Navigation.PopAsync();
        //        await Navigation.PopAsync();
        //    }
        //    else
        //    {
        //        return;
        //    }

            
        //    // Manually deselect item.
        //    AddressListView.SelectedItem = null;
        //}

        //async void OnPaymethodSelected(object sender, SelectedItemChangedEventArgs args)
        //{
        //    var item = args.SelectedItem as UserPayment;
        //    if (item == null)
        //        return;

        //    item.Id = App.LoggedInUser.SelectedPaymentId;

        //    var action = await DisplayAlert("Alert", "Would you like to change the selected Pay Method?", "Yes", "No");
        //    if (action)
        //    {
        //        App.LoggedInUser.SelectedPaymethod.Clear();
        //        await Navigation.PopAsync();
        //    }
        //    else
        //    {
        //        return;
        //    }

        //    // Manually deselect item.
        //    AddressListView.SelectedItem = null;
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //viewModel.LoadAddressPaymentsCommand.Execute(null);

            AddressListView.ItemsSource = App.LoggedInUser.SelectedAddress;
            PaymethodListView.ItemsSource = App.LoggedInUser.SelectedPaymethod;




        }

        private void Confirm_Clicked(object sender, EventArgs e)
        {
            
            viewModel.SendOrder(viewModel.ConvertShoppingCartToOrder(App.userCart, App.LoggedInUser));
            
            if (viewModel.success == true)
            {
                DisplayAlert("Success", "Your Order has been Completed", "Ok");
                App.userCart.ClearCart();
                Application.Current.MainPage = new MenuItemsPage();
            }
            else
            {
                DisplayAlert("Failure", "Something went wrong", "Ok");
                return;
            }
        }
    }
}