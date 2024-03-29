﻿using FoodOrderSystem.Xamarin.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
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

        private async Task<User> LoadFromAPI(string email, string password)
        {
            try
            {
                // Create apiUrl to distinguish between Android and iOS users
                // This was used to connect to localhost api. Android needed a redirect with Jexus Manager because the 
                // Android Emulator doesn't understand 'localhost' and needs to be told '127.0.0.1'

                //string apiUrl = null;
                //if (Device.RuntimePlatform == Device.Android)
                //    apiUrl = "http://10.0.2.2:62568/api/Login?Email=" + email + "&Password=" + password;
                //else if (Device.RuntimePlatform == Device.iOS)
                //    apiUrl = "http://localhost:62568/api/Login?Email=" + email + "&Password=" + password;


                // Create HttpClient

                HttpClient client = new HttpClient();
                //client.BaseAddress = new Uri(apiUrl);


                // Http Get

                try
                {
                    User item = new User();
                    var response = await client.GetStringAsync("http://jwfoodordersystem.azurewebsites.net/api/Login?Email=" + email + "&Password=" + password);
                    item = JsonConvert.DeserializeObject<User>(response);

                    // Return user
                    return item;
                }
                catch (Exception ex)
                {

                    throw ex;
                }

                
            }
            catch (Exception ex)
            {

                throw ex;
            }

           

        }

        public async Task<User> LogIn(string email, string password)    // Log in
        {
            if (IsBusy)
                return null;

            IsBusy = true;

            try
            {
               
                User loggedinUser = await LoadFromAPI(email, password);

                return loggedinUser;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}