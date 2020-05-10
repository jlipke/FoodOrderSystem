using FoodOrderSystem.Xamarin.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderSystem.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Menu, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Menu:
                        MenuPages.Add(id, new NavigationPage(new MenuItemsPage()));
                        break;

                    case (int)MenuItemType.ShoppingCart:
                        //if (App.IsUserLoggedIn == false)
                        //{
                            //MenuPages.Add(id, new NavigationPage(new MenuItemsPage()));
                            //MasterBehavior = MasterBehavior.Popover;
                           // await Navigation.PushAsync(new LoginPage());
                        //}
                        //if (App.IsUserLoggedIn == true)
                        //{
                            //if (App.userCart.Count == 0 || App.userCart == null)
                            //{
                            //    await DisplayAlert("Alert", "There is nothing in your cart", "Ok");
                            //    MenuPages.Add(id, new NavigationPage(new MenuItemsPage()));
                            //}
                            //else
                            //{
                                MenuPages.Add(id, new NavigationPage(new ShoppingCartPage()));
                            //}
                       // }
                        break;
                    case (int)MenuItemType.AccountDetails:
                        if (App.IsUserLoggedIn == false)
                        {
                            MenuPages.Add(id, new NavigationPage(new LoginPage()));
                        }
                        if (App.IsUserLoggedIn == true)
                        {
                            //MenuPages.Add(id, new NavigationPage(new AccountDetailsPage()));
                        }
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}