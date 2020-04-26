using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodOrderSystem.BL;
using FoodOrderSystem.BL.Models;
using System.Linq;
using System.Collections.Generic;

namespace FoodOrderSystem.BL.Test
{
    [TestClass]
    public class utUserAddress
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
            List<UserAddress> address = UserAddressManager.Load();

            int expected = 1;
            int actual = address.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            Guid userId = UserManager.Load().FirstOrDefault().Id;

            UserAddress useraddress = new UserAddress
            {
                UserId = userId,
                Address = "123 EZ Street",
                City = "OshkoshTest",
                State = "WI",
                ZipCode = "54913"
            };

            bool result = UserAddressManager.Insert(useraddress);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void UpdateTest()
        {
            List<UserAddress> addresss = UserAddressManager.Load();
            UserAddress address = addresss.Where(c => c.City == "OshkoshTest").FirstOrDefault();
            address.City = "OshkoshTest2";
            int actual = UserAddressManager.Update(address);
            Assert.IsTrue(actual > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            List<UserAddress> addresss = UserAddressManager.Load();
            UserAddress address = addresss.Where(c => c.City == "OshkoshTest2").FirstOrDefault();
            int actual = UserAddressManager.Delete(address.Id);
            Assert.IsTrue(actual > 0);
        }
    }
}
