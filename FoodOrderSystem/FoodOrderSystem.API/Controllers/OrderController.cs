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
    public class OrderController : ApiController
    {
        // GET: api/Order
        public IEnumerable<Order> Get()
        {
            return OrderManager.Load();

        }

        // GET: api/Order/5
        public Order Get(Guid id)
        {
            return OrderManager.LoadById(id); ;
        }

        // POST: api/Order
        public void Post([FromBody]Order order)
        {
            OrderManager.Insert(order);
        }

        // PUT: api/Order/5
        public void Put(Guid id, [FromBody]Order order)
        {
            OrderManager.Update(order);
        }

        // DELETE: api/Order/5
        public void Delete(Guid id)
        {
            OrderManager.Delete(id);
        }
    }
}
