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
                            Password = userRow.Password
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

        public static int Insert(User user)
        {
            try
            {
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {

                    // TODO: Hash the password when it is getting inserted
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

        public static int Insert(string firstName, string lastName, string email, string phone, string password)
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


    }
}