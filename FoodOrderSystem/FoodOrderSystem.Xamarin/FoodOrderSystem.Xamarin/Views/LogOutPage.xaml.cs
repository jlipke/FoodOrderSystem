using FoodOrderSystem.Xamarin.Models;
using FoodOrderSystem.Xamarin.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderSystem.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogOutPage : ContentPage
    {
        
        public LogOutPage()
        {
            InitializeComponent();
        }
        
        private async void LogOutClicked(object sender, EventArgs e)
        {

           App.IsUserLoggedIn = false;
           App.LoggedInUser = null;

           await DisplayAlert("Logout", "You have been Logged out ", "Ok");
           await Navigation.PopAsync();





        }
    }
}