using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderSystem.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void CreateAccountClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateAccountPage());
        }
    }
}