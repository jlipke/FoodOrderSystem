using FoodOrderSystem.Xamarin.Models;
using FoodOrderSystem.Xamarin.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderSystem.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccountPage : ContentPage
    {
        CreateAccountViewModel viewModel;

        public CreateAccountPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CreateAccountViewModel();

        }

        private async void CreateAccountClicked(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Text == null || txtReEmail.Text == null || txtPassword.Text == null || txtRePassword.Text == null || txtFirst.Text == null || txtLast.Text == null || txtPhone.Text == null)
                {
                    await DisplayAlert("Alert", "Please fill all of your information", "Ok");
                }
                else if (txtEmail.Text != txtReEmail.Text)
                {
                    await DisplayAlert("Alert", "Your emails do not match", "Ok");
                }
                else if (txtPassword.Text != txtRePassword.Text)
                {
                    await DisplayAlert("Alert", "Your passwords do not match", "Ok");
                }
                else
                {

                    string email = txtEmail.Text;
                    string password = txtPassword.Text;
                    string phone = txtPhone.Text;
                    string firstname = txtFirst.Text;
                    string lastname = txtLast.Text;

                    bool returnCode = await viewModel.CreateUser(email, password, phone, firstname, lastname);

                    if (returnCode == true)
                    {
                        await DisplayAlert("Alert", "Your Account was created Successfully", "Ok");
                        await Navigation.PushAsync(new MenuItemsPage());
                    }
                    else
                    {
                        await DisplayAlert("Alert", "Something went wrong on our end.", "Ok");
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