using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystem.BL.Models
{
    public class MenuItem
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; }
        public float Price { get; set; }
    }
}
