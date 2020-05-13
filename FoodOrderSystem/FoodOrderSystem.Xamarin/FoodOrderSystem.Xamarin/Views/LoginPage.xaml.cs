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
        MenuItemsViewModel menuVM;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new LoginViewModel();
            BindingContext = menuVM = new MenuItemsViewModel();
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

                    App.LoggedInUser = await viewModel.LogIn(email, password);



                    if (App.LoggedInUser != null)
                    {
                        App.IsUserLoggedIn = true;
                        await DisplayAlert("Login Successful", "Welcome, " + App.LoggedInUser.FirstName, "Ok");
                        await Navigation.PopAsync();


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