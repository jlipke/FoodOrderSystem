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
    public class UserAddressController : ApiController
    {
        // GET: api/UserAddress
        public IEnumerable<UserAddress> Get()
        {
            return UserAddressManager.Load();

        }

        // GET: api/UserAddress/5
        public UserAddress Get(Guid id)
        {
            return UserAddressManager.LoadById(id); ;
        }

        // POST: api/UserAddress
        public void Post([FromBody]UserAddress make)
        {
            UserAddressManager.Insert(make);
        }

        // PUT: api/UserAddress/5
        public void Put(Guid id, [FromBody]UserAddress make)
        {
            UserAddressManager.Update(make);
        }

        // DELETE: api/UserAddress/5
        public void Delete(Guid id)
        {
            UserAddressManager.Delete(id);
        }
    }
}
