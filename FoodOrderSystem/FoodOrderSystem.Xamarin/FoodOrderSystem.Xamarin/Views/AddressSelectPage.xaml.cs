using FoodOrderSystem.Xamarin.Models;
using FoodOrderSystem.Xamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderSystem.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressSelectPage : ContentPage
    {
        AddressSelectViewModel viewModel;
        MenuItemsViewModel menuVM;
        public AddressSelectPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AddressSelectViewModel();
            BindingContext = menuVM = new MenuItemsViewModel();
            

        }

        
        async void OnAddressSelected(object sender, SelectedItemChangedEventArgs args)
        {
            try
            {
                var item = args.SelectedItem as UserAddress;
                if (item == null)
                    return;

                App.LoggedInUser.SelectedAddressId = item.Id;
                App.LoggedInUser.SelectedAddress.Clear();
                App.LoggedInUser.SelectedAddress.Add(item);

                await Navigation.PushAsync(new PaymethodSelectPage());

                // Manually deselect item.
                AddressListView.SelectedItem = null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.LoadAddressCommand.Execute(null);

            AddressListView.ItemsSource = viewModel.AddressItems;
           // PaymentListView.ItemsSource = viewModel.PaymentItems;
           



        }
        
        
    }
}