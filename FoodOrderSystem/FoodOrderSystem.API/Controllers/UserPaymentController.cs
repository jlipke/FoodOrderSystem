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
    public class UserPaymentController : ApiController
    {
        // GET: api/UserPayment
        public IEnumerable<UserPayment> Get()
        {
            return UserPaymentManager.Load();

        }

        // GET: api/UserPayment/5
        public UserPayment Get(Guid id)
        {
            return UserPaymentManager.LoadById(id); ;
        }

        // POST: api/UserPayment
        public void Post([FromBody]UserPayment make)
        {
            UserPaymentManager.Insert(make);
        }

        // PUT: api/UserPayment/5
        public void Put(Guid id, [FromBody]UserPayment make)
        {
            UserPaymentManager.Update(make);
        }

        // DELETE: api/UserPayment/5
        public void Delete(Guid id)
        {
            UserPaymentManager.Delete(id);
        }
    }
}
