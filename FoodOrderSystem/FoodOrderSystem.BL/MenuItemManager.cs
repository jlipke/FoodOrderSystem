using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrderSystem.BL.Models;
using FoodOrderSystem.PL;

namespace FoodOrderSystem.BL
{
    public static class MenuItemManager
    {
        public static List<MenuItem> Load()
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    List<MenuItem> results = new List<MenuItem>();
                    dc.tblMenuItems.ToList().ForEach(p => results.Add(new MenuItem
                    {
                        Id = p.Id,
                        ItemName = p.ItemName,
                        Price = (float) p.Price,

                    }));

                    return results;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static MenuItem LoadById(Guid id)
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    tblMenuItem MenuItemRow = dc.tblMenuItems.FirstOrDefault(a => a.Id == id);

                    if (MenuItemRow != null)
                    {
                        return new MenuItem
                        {
                            Id = MenuItemRow.Id,
                            ItemName = MenuItemRow.ItemName,
                            Price = (float) MenuItemRow.Price,
                            
                        };
                    }

                    else
                    {
                        throw new Exception("Row not found...");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Insert(MenuItem menuItem)
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    // Make a new row
                    tblMenuItem newrow = new tblMenuItem();

                    // Set the properties
                    newrow.Id = Guid.NewGuid();
                    newrow.ItemName = menuItem.ItemName;
                    newrow.Price = menuItem.Price;

                    // Do the Insert
                    dc.tblMenuItems.Add(newrow);

                    // Commit the insert
                    dc.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool Insert(string itemName, float price)
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    // Make a new row
                    tblMenuItem newrow = new tblMenuItem();

                    // Set the properties
                    newrow.Id = Guid.NewGuid();
                    newrow.ItemName = itemName;
                    newrow.Price = price;

                    // Do the Insert
                    dc.tblMenuItems.Add(newrow);

                    // Commit the insert
                    dc.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int Update(Guid id, string itemName, float price)
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    tblMenuItem updatedrow = dc.tblMenuItems.FirstOrDefault(a => a.Id == id);

                    if (updatedrow != null)
                    {
                        updatedrow.ItemName = itemName;
                        updatedrow.Price = price;
                        

                        return dc.SaveChanges();
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Update(MenuItem menuItem)
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    tblMenuItem updatedrow = dc.tblMenuItems.FirstOrDefault(a => a.Id == menuItem.Id);

                    if (updatedrow != null)
                    {
                        updatedrow.ItemName = menuItem.ItemName;
                        updatedrow.Price = menuItem.Price;
                        

                        return dc.SaveChanges();
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Delete(Guid id)
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    tblMenuItem deletedrow = dc.tblMenuItems.FirstOrDefault(a => a.Id == id);

                    if (deletedrow != null)
                    {
                        dc.tblMenuItems.Remove(deletedrow);

                        return dc.SaveChanges();
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}