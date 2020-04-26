using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodOrderSystem.BL;
using FoodOrderSystem.BL.Models;
using System.Linq;
using System.Collections.Generic;

namespace FoodOrderSystem.BL.Test
{
    [TestClass]
    public class utOrder
    {
        [TestMethod]
        public void RunAll()
        {
            LoadTest();
            InsertTest();
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Order> order = OrderManager.Load();

            int expected = 1;
            int actual = order.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            Guid userId = UserManager.Load().FirstOrDefault().Id;
            Guid addressId = UserAddressManager.Load().FirstOrDefault().Id;
            Guid paymentId = UserPaymentManager.Load().FirstOrDefault().Id;
            DateTime date = DateTime.Now;

            Order order = new Order
            {
                UserId = userId,
                AddressId = addressId,
                PaymentId = paymentId,
                Date = date
            };

            bool result = OrderManager.Insert(order);
            Assert.IsTrue(result);

        }

        
    }
}
