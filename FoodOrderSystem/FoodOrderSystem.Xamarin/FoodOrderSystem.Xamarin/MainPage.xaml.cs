using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace FoodOrderSystem.Xamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadMenuItems();
        }

        public async void LoadMenuItems()
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetStringAsync("http://169.254.80.80:62568/api/MenuItem");
                var menuItems = JsonConvert.DeserializeObject<List<MenuItem>>(response);

                ListMenuItems.ItemsSource = menuItems;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

    }
}
