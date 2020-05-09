using FoodOrderSystem.Xamarin.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace FoodOrderSystem.Xamarin.ViewModels
{
    public class CreateAccountViewModel : BaseViewModel
    {
        
        public CreateAccountViewModel()
        {
            Title = "Create Account";
        }
        
        private async Task<bool> InsertIntoAPI(User user)
        {
            // Create apiUrl to distinguish between Android and iOS users
            // This was used to connect to localhost api. Android needed a redirect with Jexus Manager because the 
            // Android Emulator doesn't understand 'localhost' and needs to be told '127.0.0.1'

            //string apiUrl = null;
            //if (Device.RuntimePlatform == Device.Android)
            //    apiUrl = "http://10.0.2.2:62568/api/User";
            //else if (Device.RuntimePlatform == Device.iOS)
            //    apiUrl = "http://localhost:62568/api/User";


            // Create HttpClient
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://jwfoodordersystem.azurewebsites.net/api/User");

            // Http Post
            var postTask = await client.PostAsJsonAsync<User>("user", user);

            // Return whether or not the post was successful
            return postTask.IsSuccessStatusCode;
            
        }

        public async Task<bool> CreateUser(string email, string password, string phone, string firstname, string lastname )    // Create new user
        {
            if (IsBusy)
                return false;

            IsBusy = true;

            try
            {
                User user = new User();
                user.Email = email;
                user.Password = password;
                user.Phone = phone;
                user.FirstName = firstname;
                user.LastName = lastname;

                bool returnCode = await InsertIntoAPI(user);

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