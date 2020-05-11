using FoodOrderSystem.Xamarin.Models;
using FoodOrderSystem.Xamarin.ViewModels;
using System;

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
            var item = args.SelectedItem as UserAddress;
            if (item == null)
                return;

            item.Id = App.LoggedInUser.SelectedAddressId;
            await Navigation.PushAsync(new PaymethodSelectPage());

            // Manually deselect item.
            AddressListView.SelectedItem = null;
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