using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FoodOrderSystem.Xamarin.Models;
using FoodOrderSystem.Xamarin.Views;
using FoodOrderSystem.Xamarin.ViewModels;

namespace FoodOrderSystem.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuItemsPage : ContentPage
    {
        MenuItemsViewModel viewModel;

        public MenuItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MenuItemsViewModel();
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

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //if (viewModel.MenuItems.Count == 0)
            //    viewModel.LoadItemsCommand.Execute(null);
            //else
            viewModel.LoadItemsCommand.Execute(null);
            ItemsListView.ItemsSource = viewModel.MenuItems;
        }
    }
}