using FoodOrderSystem.Xamarin.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace FoodOrderSystem.Xamarin.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            Title = "Log In";
            
        }

        private async Task<User> LoadFromAPI(User user)
        {
            // Create apiUrl to distinguish between Android and iOS users
            string apiUrl = null;
            if (Device.RuntimePlatform == Device.Android)
                apiUrl = "http://10.0.2.2:62568/api/User";
            else if (Device.RuntimePlatform == Device.iOS)
                apiUrl = "http://localhost:62568/api/User";


            // Create HttpClient
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);

            // Http Post
            var postTask = await client.PostAsJsonAsync<User>("user", user);

            // Return whether or not the post was successful
            return postTask.IsSuccessStatusCode;

        }

        public async Task<bool> CreateUser(string email, string password)    // Log in
        {
            if (IsBusy)
                return false;

            IsBusy = true;

            try
            {
                User enteredUser = new User();
                User loggedinUser = new User();
                enteredUser.Email = email;
                enteredUser.Password = password;

                 loggedinUser = await LoadFromAPI(user);

                return returnCode;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}