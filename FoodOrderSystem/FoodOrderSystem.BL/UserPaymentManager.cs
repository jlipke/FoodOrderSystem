using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrderSystem.BL.Models;
using FoodOrderSystem.PL;

namespace FoodOrderSystem.BL
{
    public static class UserPaymentManager
    {
        public static List<UserPayment> Load()
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    List<UserPayment> results = new List<UserPayment>();
                    dc.tblUserPayments.ToList().ForEach(p => results.Add(new UserPayment
                    {
                        Id = p.Id,
                        UserId = p.UserId,
                        CardHolderName = p.CardHolderName,
                        CardNumber = p.CardNumber,
                        ExpirationDate = p.ExpirationDate,
                        CVC = p.CVC

                    }));

                    return results;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static UserPayment LoadById(Guid id)
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    tblUserPayment UserPaymentRow = dc.tblUserPayments.FirstOrDefault(a => a.Id == id);

                    if (UserPaymentRow != null)
                    {
                        return new UserPayment
                        {
                            Id = UserPaymentRow.Id,
                            UserId = UserPaymentRow.UserId,
                            CardHolderName = UserPaymentRow.CardHolderName,
                            CardNumber = UserPaymentRow.CardNumber,
                            ExpirationDate = UserPaymentRow.ExpirationDate,
                            CVC = UserPaymentRow.CVC

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
        public static List<UserPayment> LoadByUserId(Guid userid)
        {
            try
            {
                    List<UserPayment> payMethods = new List<UserPayment>();
                    using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                    {
                        tblUser row = dc.tblUsers.FirstOrDefault(a => a.Id == userid);

                        var results = (from v in dc.tblUserPayments
                                   where v.UserId == row.Id
                                   select v).ToList();
                            
                            results.ForEach(p => payMethods.Add(new UserPayment
                            {
                                Id = p.Id,
                                UserId = p.UserId,
                                CardHolderName = p.CardHolderName,
                                CardNumber = p.CardNumber,
                                ExpirationDate = p.ExpirationDate,
                                CVC = p.CVC
                            }));
                    
                    }
                    return payMethods;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static UserPayment LoadByUserAndPaymentId(Guid paymentid, Guid userid)
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    tblUserPayment row = dc.tblUserPayments.FirstOrDefault(a => a.Id == paymentid
                                                                              && a.UserId == userid);
                    if (row != null)
                    {
                        return new UserPayment
                        {
                            Id = row.Id,
                            UserId = row.UserId,
                            CardHolderName = row.CardHolderName,
                            CardNumber = row.CardNumber,
                            ExpirationDate = row.ExpirationDate,
                            CVC = row.CVC
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
        public static bool Insert(UserPayment userPayment)
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    // Make a new row
                    tblUserPayment newrow = new tblUserPayment();

                    // Set the properties
                    newrow.Id = Guid.NewGuid();
                    newrow.UserId = userPayment.UserId;
                    newrow.CardHolderName = userPayment.CardHolderName;
                    newrow.CardNumber = userPayment.CardNumber;
                    newrow.ExpirationDate = userPayment.ExpirationDate;
                    newrow.CVC = userPayment.CVC;

                    // Do the Insert
                    dc.tblUserPayments.Add(newrow);

                    // Commit the insert
                    
                    return Convert.ToBoolean(dc.SaveChanges()); 
                }
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public static bool Insert(Guid userid, string cardholdername, string cardnumber, string expirationdate, string cvc)
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    // Make a new row
                    tblUserPayment newrow = new tblUserPayment();

                    // Set the properties
                    newrow.Id = Guid.NewGuid();
                    newrow.UserId = userid;
                    newrow.CardHolderName = cardholdername;
                    newrow.CardNumber = cardnumber;
                    newrow.ExpirationDate = expirationdate;
                    newrow.CVC = cvc;

                    // Do the Insert
                    dc.tblUserPayments.Add(newrow);

                    // Commit the insert
                    return Convert.ToBoolean(dc.SaveChanges());
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int Update(Guid id, Guid userid, string cardholdername, string cardnumber, string expirationdate, string cvc)
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    tblUserPayment updatedrow = dc.tblUserPayments.FirstOrDefault(a => a.Id == id);

                    if (updatedrow != null)
                    {
                        updatedrow.UserId = userid;
                        updatedrow.CardHolderName = cardholdername;
                        updatedrow.CardNumber = cardnumber;
                        updatedrow.ExpirationDate = expirationdate;
                        updatedrow.CVC = cvc;


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

        public static int Update(UserPayment userPayment)
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    tblUserPayment updatedrow = dc.tblUserPayments.FirstOrDefault(a => a.Id == userPayment.Id);

                    if (updatedrow != null)
                    {
                        
                        updatedrow.UserId = userPayment.UserId;
                        updatedrow.CardHolderName = userPayment.CardHolderName;
                        updatedrow.CardNumber = userPayment.CardNumber;
                        updatedrow.ExpirationDate = userPayment.ExpirationDate;
                        updatedrow.CVC = userPayment.CVC;


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
                    tblUserPayment deletedrow = dc.tblUserPayments.FirstOrDefault(a => a.Id == id);

                    if (deletedrow != null)
                    {
                        dc.tblUserPayments.Remove(deletedrow);

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