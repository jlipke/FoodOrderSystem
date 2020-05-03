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
    public class UserController : ApiController
    {
        // GET: api/User
        public IEnumerable<User> Get()
        {
            return UserManager.Load();

        }

        // GET: api/User/5
        public User Get(Guid id)
        {
            return UserManager.LoadById(id); ;
        }

        // POST: api/User
        public void Post([FromBody]User user)
        {
            UserManager.Insert(user);
        }

        // PUT: api/User/5
        public void Put(Guid id, [FromBody]User user)
        {
            UserManager.Update(user);
        }

        // DELETE: api/User/5
        public void Delete(Guid id)
        {
            UserManager.Delete(id);
        }
    }
}
