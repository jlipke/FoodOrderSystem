using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace FoodOrderSystem.Xamarin.ViewModels
{
    public class CreateAccountViewModel : BaseViewModel
    {
        public CreateAccountViewModel()
        {
            Title = "Create Account";

            CreateAccountCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        
        public ICommand CreateAccountCommand { get; }

        public 
    }
}