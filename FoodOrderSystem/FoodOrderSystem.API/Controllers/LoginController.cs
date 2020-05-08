using FoodOrderSystem.BL;
using FoodOrderSystem.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodOrderSystem.API.Controllers
{
    public class LoginController : ApiController
    {

        // GET: api/Login/
        public User Get(string email, string password)
        {
            return UserManager.LoadByEmail(email, password);
        }

        
    }
}
