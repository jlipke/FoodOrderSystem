using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace FoodOrderSystem.Xamarin.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            Title = "Log In";

            LogInCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand LogInCommand { get; }
        public ICommand CreateAccountCommand { get; }
    }
}