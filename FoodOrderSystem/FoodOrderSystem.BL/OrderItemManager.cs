using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrderSystem.BL.Models;
using FoodOrderSystem.PL;

namespace FoodOrderSystem.BL
{
    public static class OrderItemManager
    {
        public static List<OrderItem> LoadByOrderId(Guid orderid)
        {
            try
            {
                List<OrderItem> orderItems = new List<OrderItem>();
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                    {

                        tblOrder row = dc.tblOrders.FirstOrDefault(p => p.Id == orderid);

                    var results = (from v in dc.tblOrderItems
                                   where v.OrderId == row.Id
                                   select v).ToList();
                        
                            
                            results.ForEach(p => orderItems.Add(new OrderItem
                            {
                                Id = p.Id,
                                OrderId = p.OrderId,
                                MenuItemId = p.MenuItemId
                            }));

                            return orderItems;
                    
                    }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<OrderItem> Load()
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    List<OrderItem> results = new List<OrderItem>();
                    dc.tblOrderItems.ToList().ForEach(p => results.Add(new OrderItem
                    {
                        Id = p.Id,
                        OrderId = p.OrderId,
                        MenuItemId = p.MenuItemId,

                    }));
                    
                    return results;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static OrderItem LoadById(Guid id)
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                { 
                    List<OrderItem> results = new List<OrderItem>();
                    tblOrderItem orderItem = dc.tblOrderItems.FirstOrDefault(m => m.Id == id); // Get the id that matches the one that was passed in

                    dc.tblOrderItems.ToList().ForEach(v => results.Add(new OrderItem
                    {
                        Id = v.Id,
                        OrderId = v.OrderId,
                        MenuItemId = v.tblMenuItem.Id
                    }));
                    

                    if (results != null)
                    {
                        return new OrderItem
                        {
                            Id = orderItem.Id,
                            OrderId = orderItem.OrderId,
                            MenuItemId = orderItem.tblMenuItem.Id
                            
                        };
                    }
                    else
                    {
                        throw new Exception("Cannot find the row.");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool Insert(OrderItem orderItem)
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    // Make a new row
                    tblOrderItem newrow = new tblOrderItem();

                    // Set the properties
                    newrow.Id = Guid.NewGuid();
                    newrow.OrderId = orderItem.OrderId;
                    newrow.MenuItemId = orderItem.MenuItemId;

                    // Do the Insert
                    dc.tblOrderItems.Add(newrow);

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

        public static bool Insert(Guid orderId, Guid menuItemId)
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    // Make a new row
                    tblOrderItem newrow = new tblOrderItem();

                    // Set the properties
                    newrow.Id = Guid.NewGuid();
                    newrow.OrderId = orderId;
                    newrow.MenuItemId = menuItemId;

                    // Do the Insert
                    dc.tblOrderItems.Add(newrow);

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

        public static int Update(Guid id, Guid orderId, Guid menuItemId)
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    tblOrderItem updatedrow = dc.tblOrderItems.FirstOrDefault(a => a.Id == id);

                    if (updatedrow != null)
                    {
                        updatedrow.OrderId = orderId;
                        updatedrow.MenuItemId = menuItemId;


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

        public static int Update(OrderItem orderItem)
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    tblOrderItem updatedrow = dc.tblOrderItems.FirstOrDefault(a => a.Id == orderItem.Id);

                    if (updatedrow != null)
                    {
                        updatedrow.OrderId = orderItem.OrderId;
                        updatedrow.MenuItemId = orderItem.MenuItemId;


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
                    tblOrderItem deletedrow = dc.tblOrderItems.FirstOrDefault(a => a.Id == id);

                    if (deletedrow != null)
                    {
                        dc.tblOrderItems.Remove(deletedrow);

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