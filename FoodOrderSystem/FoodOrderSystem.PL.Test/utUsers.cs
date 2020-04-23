using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodOrderSystem.PL;
using System.Linq;

namespace FoodOrderSystem.PL.Test
{
    [TestClass]
    public class utUsers
    {
        [TestMethod]
        public void RunAll()
        {
            LoadTest();
            InsertTest();
            UpdateTest();
            DeleteTest();
        }
        public void LoadTest()
        {
            using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
            {
                int expected = 1;
                var results = dc.tblUsers.ToList();
                int actual = results.Count;

                Assert.AreEqual(expected, actual);
            }
        }
        public void InsertTest()
        {
            using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
            {
                tblUser newrow = new tblUser();

                newrow.Id = Guid.NewGuid();
                newrow.FirstName = "Allie";
                newrow.LastName = "Lewandowski";
                newrow.Email = "alewi@hotmail.com";
                newrow.Phone = "9201234567";
                newrow.Password = "P@SSW0RD";

                dc.tblUsers.Add(newrow);
                int results = dc.SaveChanges();

                Assert.IsTrue(results != 0);
            }
        }
        [TestMethod]
        public void spCreateUserTest()
        {

        }
        public void UpdateTest()
        {
            using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
            {
                tblUser updatedrow = dc.tblUsers.Where(u => u.Email == "alewi@hotmail.com")
                    .FirstOrDefault();

                if (updatedrow != null)
                {
                    updatedrow.Password = "NewP@SSw0Rd";
                    updatedrow.Phone = "9208881122";

                    int results = dc.SaveChanges();

                    Assert.IsTrue(results != 0);
                }
            }
        }
        public void DeleteTest()
        {
            using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
            {
                tblUser deletedrow = dc.tblUsers.Where(u => u.Email == "alewi@hotmail.com")
                    .FirstOrDefault();

                if (deletedrow != null)
                {
                    dc.tblUsers.Remove(deletedrow);
                    int results = dc.SaveChanges();
                    Assert.IsTrue(results != 0);
                }
            }
        }
    }
}
