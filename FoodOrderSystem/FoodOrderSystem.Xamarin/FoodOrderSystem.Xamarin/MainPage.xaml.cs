using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FoodOrderSystem.Xamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadMenuItems();
        }

        // If Device is Android, use the first address, otherwise use the second
        //public static string BaseAddress =
        //    Device.RuntimePlatform == Device.Android ? "https://10.0.2.2:62568/api" : "https://localhost:62568/api";
        //public static string ItemsUrl = $"{BaseAddress}/api/MenuItem/";

        private static HttpClient InitializeClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://10.0.2.2:62568/api/");
                return client;
        }
      
        public async void LoadMenuItems()
        {
            //// Bypass the certificate Security check for localhost web services
            //HttpClientHandler handler = new HttpClientHandler();
            //handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            //{
            //    if (cert.Issuer.Equals("CN=localhost"))
            //        return true;
            //    return errors == System.Net.Security.SslPolicyErrors.None;
            //};

            // Create HttpClient
            //  HttpClient httpClient = new HttpClient(/*handler*/);
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://169.254.80.80:62568/api/MenuItem");
            var items = JsonConvert.DeserializeObject<List<MenuItem>>(response);

            //var response = await httpClient.GetStringAsync(ItemsUrl);

            //List<MenuItem> items = JsonConvert.DeserializeObject(json);

            // Populate the List of Items
            ListMenuItems.ItemsSource = items;
            
            
        }

    }
}
