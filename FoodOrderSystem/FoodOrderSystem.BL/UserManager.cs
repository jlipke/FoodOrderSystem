using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrderSystem.BL.Models;
using FoodOrderSystem.PL;

namespace FoodOrderSystem.BL
{
    public static class UserManager
    {
        public static List<User> Load()
        {
            try
            {
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {
                    List<User> results = new List<User>();
                    dc.tblUsers.ToList().ForEach(p => results.Add(new User
                    {
                        Id = p.Id,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        Email = p.Email,
                        Phone = p.Phone,
                        Password = p.Password,
                        Addresses = UserAddressManager.LoadByUserId(p.Id),
                        Payments = UserPaymentManager.LoadByUserId(p.Id)

                    }));

                    
                    return results;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static User LoadById(Guid id)
        {
            try
            {
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {
                    tblUser userRow = dc.tblUsers.FirstOrDefault(a => a.Id == id);

                    if (userRow != null)
                    {
                        return new User
                        {
                            Id = userRow.Id,
                            FirstName = userRow.FirstName,
                            LastName = userRow.LastName,
                            Email = userRow.Email,
                            Phone = userRow.Phone,
                            Password = userRow.Password,
                            Addresses = UserAddressManager.LoadByUserId(id),
                            Payments = UserPaymentManager.LoadByUserId(id)
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

        public static User LoadByEmail(string email, string password)
        {
            try
            {
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {
                    tblUser userRow = dc.tblUsers.FirstOrDefault(a => a.Email == email && a.Password == password);

                    if (userRow != null)
                    {
                        return new User
                        {
                            Id = userRow.Id,
                            FirstName = userRow.FirstName,
                            LastName = userRow.LastName,
                            Email = userRow.Email,
                            Phone = userRow.Phone,
                            Password = userRow.Password,
                            Addresses = UserAddressManager.LoadByUserId(userRow.Id),
                            Payments = UserPaymentManager.LoadByUserId(userRow.Id)
                        };
                    }

                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Insert(User user)
        {
            try
            {
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {
                    // Make a new row
                    tblUser newrow = new tblUser();

                    // Set the properties
                    newrow.Id = Guid.NewGuid();
                    newrow.FirstName = user.FirstName;
                    newrow.LastName = user.LastName;
                    newrow.Phone = user.Phone;
                    newrow.Email = user.Email;
                    newrow.Password = user.Password;

                    user.Id = newrow.Id;

                    // Do the Insert
                    dc.tblUsers.Add(newrow);

                    // Commit the insert

                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int InsertSP(User user)
        {
            try
            {
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {

                    // TODO: Hash the password when it is getting inserted. May hash it at the user level 
                    var result = dc.spCreateUser(user.FirstName, user.LastName, user.Email, user.Phone, user.Password);

                    dc.SaveChanges();
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int InsertSP(string firstName, string lastName, string email, string phone, string password)
        {
            try
            {
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {
                    var result = dc.spCreateUser(firstName, lastName, email, phone, password);

                    dc.SaveChanges();
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public static int Update(Guid id, string firstName, string lastName, string email, string phone, string password)
        {
            try
            {
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {
                    tblUser updatedrow = dc.tblUsers.FirstOrDefault(a => a.Id == id);

                    if (updatedrow != null)
                    {
                        updatedrow.FirstName = firstName;
                        updatedrow.LastName = lastName;
                        updatedrow.Email = email;
                        updatedrow.Phone = phone;
                        updatedrow.Password = password;

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

        public static int Update(User user)
        {
            try
            {
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {
                    tblUser updatedrow = dc.tblUsers.FirstOrDefault(a => a.Id == user.Id);

                    if (updatedrow != null)
                    {
                        updatedrow.FirstName = user.FirstName;
                        updatedrow.LastName = user.LastName;
                        updatedrow.Email = user.Email;
                        updatedrow.Phone = user.Phone;
                        updatedrow.Password = user.Password;

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
                    tblUser deletedrow = dc.tblUsers.FirstOrDefault(a => a.Id == id);

                    if (deletedrow != null)
                    {
                        dc.tblUsers.Remove(deletedrow);

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

        public static int Login(string userEmail, string userPassword, out Guid id)
        {
            try
            {
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {
                    tblUser user = dc.tblUsers.FirstOrDefault(l => l.Email == userEmail &&
                                                                   l.Password == userPassword);
                    if (user != null)
                    {
                        id = user.Id;
                        return 1;
                    }
                    else
                    {
                        id = Guid.Empty;
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