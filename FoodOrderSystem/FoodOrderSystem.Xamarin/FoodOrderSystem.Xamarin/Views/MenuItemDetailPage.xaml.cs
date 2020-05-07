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

        public MenuItemDetailPage()
        {
            InitializeComponent();

            var item = new MenuItem
            {
                ItemName = "Item Name",
                Price = (float)4.99
            };

            viewModel = new MenuItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}