using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FoodOrderSystem.BL;
using FoodOrderSystem.BL.Models;

namespace FoodOrderSystem.API.Controllers
{
    public class OrderItemController : ApiController
    {
        // GET: api/OrderItem
        public IEnumerable<OrderItem> Get()
        {
            return OrderItemManager.Load();

        }

        // GET: api/OrderItem/5
        public OrderItem Get(Guid id)
        {
            return OrderItemManager.LoadById(id); ;
        }

        // POST: api/OrderItem
        public void Post([FromBody]OrderItem make)
        {
            //OrderItemManager.Insert(make);
        }

        // PUT: api/OrderItem/5
        public void Put(Guid id, [FromBody]OrderItem make)
        {
            OrderItemManager.Update(make);
        }

        // DELETE: api/OrderItem/5
        public void Delete(Guid id)
        {
            OrderItemManager.Delete(id);
        }
    }
}
