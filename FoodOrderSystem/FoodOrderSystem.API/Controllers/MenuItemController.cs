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
    public class MenuItemController : ApiController
    {
        // GET: api/MenuItem
        public IEnumerable<MenuItem> Get()
        {
            return MenuItemManager.Load();

        }

        // GET: api/MenuItem/5
        public MenuItem Get(Guid id)
        {
            return MenuItemManager.LoadById(id); ;
        }

        // POST: api/MenuItem
        public void Post([FromBody]MenuItem make)
        {
            MenuItemManager.Insert(make);
        }

        // PUT: api/MenuItem/5
        public void Put(Guid id, [FromBody]MenuItem make)
        {
            MenuItemManager.Update(make);
        }

        // DELETE: api/MenuItem/5
        public void Delete(Guid id)
        {
            MenuItemManager.Delete(id);
        }
    }
}
