using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystem.BL.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public Guid PaymentId { get; set; }
        public DateTime Date { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
