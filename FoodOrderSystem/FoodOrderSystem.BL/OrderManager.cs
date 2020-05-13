using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrderSystem.BL.Models;
using FoodOrderSystem.PL;

namespace FoodOrderSystem.BL
{
    public static class OrderManager
    {
        public static List<Order> Load()
        {
            try
            {
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {
                    List<Order> results = new List<Order>();
                    dc.tblOrders.ToList().ForEach(p => results.Add(new Order
                    {
                        Id = p.Id,
                        UserId = p.UserId,
                        AddressId = p.AddressId,
                        PaymentId = p.PaymentId,
                        Date = p.Date,
                        OrderItems = OrderItemManager.LoadByOrderId(p.Id)
                        // Add OrderItems
                        

                    }));

                    return results;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Order LoadById(Guid id)
        {
            try
            {
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {
                    tblOrder OrderRow = dc.tblOrders.FirstOrDefault(a => a.Id == id);

                    if (OrderRow != null)
                    {
                        return new Order
                        {
                            Id = OrderRow.Id,
                            UserId = OrderRow.UserId,
                            AddressId = OrderRow.AddressId,
                            PaymentId = OrderRow.PaymentId,
                            Date = OrderRow.Date

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

        public static List<Order> LoadByCustomerId(Guid userid)
        {
            try
            {
                if (userid != null)
                {
                    using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                    {
                        tblOrder tblorder = dc.tblOrders.FirstOrDefault(p => p.UserId == userid);

                        if (tblorder != null)
                        {
                            List<Order> orders = new List<Order>();
                            dc.tblOrders.ToList().ForEach(p => orders.Add(new Order
                            {
                                Id = tblorder.Id,
                                UserId = tblorder.UserId,
                                AddressId = tblorder.AddressId,
                                PaymentId = tblorder.PaymentId,
                                Date = tblorder.Date
                            }));

                            return orders;

                        }
                        else
                        {
                            throw new Exception("Row was not found.");
                        }
                    }
                }
                else
                {
                    throw new Exception("Please provide an id");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool Insert(Order order)
        {
            try
            {
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {
                    // Make a new row
                    tblOrder newrow = new tblOrder();

                    // Set the properties
                    newrow.Id = Guid.NewGuid();
                    newrow.UserId = order.UserId;
                    newrow.AddressId = order.AddressId;
                    newrow.PaymentId = order.PaymentId;
                    newrow.Date = order.Date;

                    order.Id = newrow.Id;

                    // Do the Insert
                    dc.tblOrders.Add(newrow);

                    // Commit the insert

                    return Convert.ToBoolean(dc.SaveChanges());
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool Insert(Guid userid, Guid addressid, Guid paymentid, DateTime date)
        {
            try
            {
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {
                    // Make a new row
                    tblOrder newrow = new tblOrder();

                    // Set the properties
                    newrow.Id = Guid.NewGuid();
                    newrow.UserId = userid;
                    newrow.AddressId = addressid;
                    newrow.PaymentId = paymentid;
                    newrow.Date = date;

                    // Do the Insert
                    dc.tblOrders.Add(newrow);

                    // Commit the insert
                    return Convert.ToBoolean(dc.SaveChanges());
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int Update(Guid id, Guid userid, Guid addressid, Guid paymentid, DateTime date)
        {
            try
            {
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {
                    tblOrder updatedrow = dc.tblOrders.FirstOrDefault(a => a.Id == id);

                    if (updatedrow != null)
                    {
                        updatedrow.UserId = userid;
                        updatedrow.AddressId = addressid;
                        updatedrow.PaymentId = paymentid;
                        updatedrow.Date = date;

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

        public static int Update(Order order)
        {
            try
            {
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {
                    tblOrder updatedrow = dc.tblOrders.FirstOrDefault(a => a.Id == order.Id);

                    if (updatedrow != null)
                    {
                        updatedrow.UserId = order.UserId;
                        updatedrow.AddressId = order.AddressId;
                        updatedrow.PaymentId = order.PaymentId;
                        updatedrow.Date = order.Date;


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
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {
                    tblOrder deletedrow = dc.tblOrders.FirstOrDefault(a => a.Id == id);

                    if (deletedrow != null)
                    {
                        dc.tblOrders.Remove(deletedrow);

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