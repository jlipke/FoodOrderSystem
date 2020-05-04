using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodOrderSystem.PL;
using System.Linq;

namespace FoodOrderSystem.PL.Test
{
    [TestClass]
    public class utMenuItems
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
            using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
            {
                int expected = 2;
                var results = dc.tblMenuItems.ToList();
                int actual = results.Count;

                Assert.AreEqual(expected, actual);
            }
        }
        [TestMethod]
        public void InsertTest()
        {
            using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
            {
                tblMenuItem newrow = new tblMenuItem();

                newrow.Id = Guid.NewGuid();
                newrow.ItemName = "Spaghetti";
                newrow.Price = 15.99;

                dc.tblMenuItems.Add(newrow);
                int results = dc.SaveChanges();

                Assert.IsTrue(results != 0);
            }
        }
        [TestMethod]
        public void UpdateTest()
        {
            using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
            {
                tblMenuItem updatedrow = dc.tblMenuItems.Where(mi => mi.ItemName == "Spaghetti")
                    .FirstOrDefault();

                if (updatedrow != null)
                {
                    updatedrow.Price = 19.99;

                    int results = dc.SaveChanges();

                    Assert.IsTrue(results != 0);
                }
            }
        }
        [TestMethod]
        public void DeleteTest()
        {
            using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
            {
                tblMenuItem deletedrow = dc.tblMenuItems.Where(mi => mi.ItemName == "Spaghetti")
                    .FirstOrDefault();

                if (deletedrow != null)
                {
                    dc.tblMenuItems.Remove(deletedrow);
                    int results = dc.SaveChanges();
                    Assert.IsTrue(results != 0);
                }
            }
        }
    }
}
