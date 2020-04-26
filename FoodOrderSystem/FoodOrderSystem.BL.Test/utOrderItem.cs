using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodOrderSystem.BL;
using FoodOrderSystem.BL.Models;
using System.Linq;
using System.Collections.Generic;

namespace FoodOrderSystem.BL.Test
{
    [TestClass]
    public class utOrderItem
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
            List<OrderItem> orderItem = OrderItemManager.Load();

            int expected = 1;
            int actual = orderItem.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            Guid orderId = OrderManager.Load().FirstOrDefault().Id;
            Guid menuItemId = MenuItemManager.Load().FirstOrDefault().Id;

            OrderItem orderItem = new OrderItem
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                MenuItemId = menuItemId
            };

            bool result = OrderItemManager.Insert(orderItem);
            Assert.IsTrue(result);

        }
        
    }
}
