using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FoodOrderSystem.Xamarin.Views;
using FoodOrderSystem.Xamarin.Models;
using System.Collections.Generic;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FoodOrderSystem.Xamarin
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        public static User LoggedInUser { get; set; }
        //public Order userCart { get; set; }
        public static List<MenuItem> userCart = new List<MenuItem>();
       

        public App()
        {
            InitializeComponent();
            
            MainPage = new MainPage();
            LoggedInUser = null;
            IsUserLoggedIn = false;

        }

        protected override void OnStart()
        {
            // Handle when your app starts
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
