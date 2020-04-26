using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodOrderSystem.BL;
using FoodOrderSystem.BL.Models;
using System.Linq;
using System.Collections.Generic;

namespace FoodOrderSystem.BL.Test
{
    [TestClass]
    public class utMenuItem
    {
        [TestMethod]
        public void RunAll()
        {
            LoadTest();
            InsertTest();
            UpdateTest();
            DeleteTest();
        }

        [TestMethod]
        public void LoadTest()
        {
            List<MenuItem> menuItem = MenuItemManager.Load();

            int expected = 2;
            int actual = menuItem.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {

            MenuItem menuItem = new MenuItem
            {
                Id = Guid.NewGuid(),
                ItemName = "Garlic Bread",
                Price = (float)3.99
            };

            bool result = MenuItemManager.Insert(menuItem);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void UpdateTest()
        {
            List<MenuItem> menuItems = MenuItemManager.Load();
            MenuItem menuItem = menuItems.Where(c => c.ItemName == "Garlic Bread").FirstOrDefault();
            menuItem.ItemName = "Cheesy Garlic Bread";
            int actual = MenuItemManager.Update(menuItem);
            Assert.IsTrue(actual > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            List<MenuItem> menuItems = MenuItemManager.Load();
            MenuItem menuItem = menuItems.Where(c => c.ItemName == "Cheesy Garlic Bread").FirstOrDefault();
            int actual = MenuItemManager.Delete(menuItem.Id);
            Assert.IsTrue(actual > 0);
        }
    }
}
