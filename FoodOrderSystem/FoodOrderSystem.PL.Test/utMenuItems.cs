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
        public void LoadTest()
        {
            using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
            {
                int expected = 2;
                var results = dc.tblMenuItems.ToList();
                int actual = results.Count;

                Assert.AreEqual(expected, actual);
            }
        }
        public void InsertTest()
        {
            using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
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
        public void UpdateTest()
        {
            using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
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
        public void DeleteTest()
        {
            using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
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
