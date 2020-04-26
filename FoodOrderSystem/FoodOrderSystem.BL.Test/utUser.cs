using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodOrderSystem.BL;
using FoodOrderSystem.BL.Models;
using System.Linq;
using System.Collections.Generic;

namespace FoodOrderSystem.BL.Test
{
    [TestClass]
    public class utUser
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
            List<User> user = UserManager.Load();

            int expected = 1;
            int actual = user.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {

            User user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Hancock",
                Email = "XxIamJohnHancock420xX@gmail.com",
                Phone = "9201231234",
                Password = "12345"
            };

            int result = UserManager.Insert(user);
            Assert.IsTrue(result > 0);

        }

        [TestMethod]
        public void UpdateTest()
        {
            List<User> users = UserManager.Load();
            User user = users.Where(c => c.LastName == "Hancock").FirstOrDefault();
            user.LastName = "Test";
            int actual = UserManager.Update(user);
            Assert.IsTrue(actual > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            List<User> users = UserManager.Load();
            User user = users.Where(c => c.LastName == "Test").FirstOrDefault();
            int actual = UserManager.Delete(user.Id);
            Assert.IsTrue(actual > 0);
        }
    }
}
