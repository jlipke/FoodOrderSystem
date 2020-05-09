using FoodOrderSystem.Xamarin.Models;
using FoodOrderSystem.Xamarin.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderSystem.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel viewModel;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new LoginViewModel();
        }

        async void CreateAccountClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateAccountPage());
        }

        private async void LoginClicked(object sender, EventArgs e)
        {
            try
            {
                if(txtEmail.Text == null || txtPassword.Text == null)
                {
                    await DisplayAlert("Alert", "Please fill all of your information", "Ok");
                }
                else
                {
                    string email = txtEmail.Text;
                    string password = txtPassword.Text;

                    User loggedinuser = await viewModel.LogIn(email, password);

                    if (loggedinuser != null)
                    {
                        await DisplayAlert("Login Successful", "Welcome, " + loggedinuser.FirstName, "Ok");
                        App.IsUserLoggedIn = true;
                        App.LoggedInUser = loggedinuser;
                        await Navigation.PushAsync(new MenuItemsPage());
                    }

                    else
                    {
                        await DisplayAlert("Alert", "Incorrect Login information ", "Ok");
                    }

                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}