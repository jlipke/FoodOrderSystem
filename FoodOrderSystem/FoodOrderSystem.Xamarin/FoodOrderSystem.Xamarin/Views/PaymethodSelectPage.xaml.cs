using FoodOrderSystem.Xamarin.Models;
using FoodOrderSystem.Xamarin.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderSystem.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymethodSelectPage : ContentPage
    {
        PaymethodSelectViewModel viewModel;
        MenuItemsViewModel menuVM;
        public PaymethodSelectPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new PaymethodSelectViewModel();
            BindingContext = menuVM = new MenuItemsViewModel();
            

        }

        
        async void OnPaymethodSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as UserAddress;
            if (item == null)
                return;

            item.Id = App.LoggedInUser.SelectedPaymentId;
            //await Navigation.PushAsync(new UserCartItemDetailPage(new UserCartItemDetailViewModel(item)));

            // Manually deselect item.
            PaymethodListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                viewModel.LoadPaymethodCommand.Execute(null);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            PaymethodListView.ItemsSource = viewModel.PaymentItems;
            




        }
        
        
    }
}