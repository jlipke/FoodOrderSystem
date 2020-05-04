using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using FoodOrderSystem.BL.Models;

namespace FoodOrderSystem.API.Test
{
    public class utMenuItem
    {
        private static HttpClient InitializeClient()
        {
            HttpClient client = new HttpClient();
            // Address of the Web API
            client.BaseAddress = new Uri("Http://localhost:50499/api/");
            return client;
        }

        [TestMethod]
        public void LoadTest()
        {

            HttpClient client = InitializeClient();
            HttpResponseMessage response = client.GetAsync("Make").Result;
            string result = response.Content.ReadAsStringAsync().Result;

            dynamic items = (JArray)JsonConvert.DeserializeObject(result);
            List<Make> makes = items.ToObject<List<Make>>();

            Assert.AreEqual(2, makes.Count);
        }
    }
}
