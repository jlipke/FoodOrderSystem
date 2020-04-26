using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodOrderSystem.BL;
using FoodOrderSystem.BL.Models;
using System.Linq;
using System.Collections.Generic;

namespace FoodOrderSystem.BL.Test
{
    [TestClass]
    public class utUserPayment
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
            List<UserPayment> paymethods = UserPaymentManager.Load();

            int expected = 1;
            int actual = paymethods.Count;

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void InsertTest()
        {
            Guid userId = UserManager.Load().FirstOrDefault().Id;

            UserPayment userpayment = new UserPayment
            {
                UserId = userId,
                CardHolderName = "John Hancock",
                CardNumber = "1234432109877890",
                ExpirationDate = "0222",
                CVC = "123"
            };

            bool result = UserPaymentManager.Insert(userpayment);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void UpdateTest()
        {
            List<UserPayment> paymethods = UserPaymentManager.Load();
            UserPayment paymethod = paymethods.Where(c => c.CardHolderName == "John Hancock").FirstOrDefault();
            paymethod.CardHolderName = "John Test Hancook";
            int actual = UserPaymentManager.Update(paymethod);
            Assert.IsTrue(actual > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            List<UserPayment> paymethods = UserPaymentManager.Load();
            UserPayment paymethod = paymethods.Where(c => c.CardHolderName == "John Test Hancook").FirstOrDefault();
            int actual = UserPaymentManager.Delete(paymethod.Id);
            Assert.IsTrue(actual > 0);
        }
    }
}
