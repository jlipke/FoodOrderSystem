﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrderSystem.BL.Models;
using FoodOrderSystem.PL;

namespace FoodOrderSystem.BL
{
    public static class UserAddressManager
    {
        public static List<UserAddress> Load()
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    List<UserAddress> results = new List<UserAddress>();
                    dc.tblUserAddresses.ToList().ForEach(p => results.Add(new UserAddress
                    {
                        Id = p.Id,
                        UserId = p.UserId,
                        Address = p.Address,
                        City = p.City,
                        State = p.State,
                        ZipCode = p.ZipCode

                    }));

                    return results;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<State> LoadStates()
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    List<State> results = new List<State>();
                    dc.tblStates.ToList().ForEach(s => results.Add(new State
                    {
                        Id = s.Id,
                        Name = s.Name
                    }));

                    return results;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static UserAddress LoadById(Guid id)
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    tblUserAddress UserAddressRow = dc.tblUserAddresses.FirstOrDefault(a => a.Id == id);

                    if (UserAddressRow != null)
                    {
                        return new UserAddress
                        {
                            Id = UserAddressRow.Id,
                            UserId = UserAddressRow.UserId,
                            Address = UserAddressRow.Address,
                            City = UserAddressRow.City,
                            State = UserAddressRow.State,
                            ZipCode = UserAddressRow.ZipCode

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

        public static List<UserAddress> LoadByUserId(Guid userid)
        {
            try
            {
                List<UserAddress> addresses = new List<UserAddress>();
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    tblUser row = dc.tblUsers.FirstOrDefault(a => a.Id == userid);

                    var results = (from v in dc.tblUserAddresses
                                   where v.UserId == row.Id
                                   select v).ToList();

                    results.ForEach(p => addresses.Add(new UserAddress
                    {

                        Id = p.Id,
                        UserId = p.UserId,
                        Address = p.Address,
                        City = p.City,
                        State = p.State,
                        ZipCode = p.ZipCode

                    }));
                }
                return addresses;
                  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public static UserAddress LoadByUserAndAddressId(Guid addressid, Guid userid)
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    tblUserAddress row = dc.tblUserAddresses.FirstOrDefault(a => a.Id == addressid
                                                                              && a.UserId == userid);
                    if (row != null)
                    {
                        return new UserAddress
                        {
                            Id = row.Id,
                            UserId = row.UserId,
                            Address = row.Address,
                            City = row.City,
                            State = row.State,
                            ZipCode = row.ZipCode
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

        public static bool Insert(UserAddress userAddress)
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    // Make a new row
                    tblUserAddress newrow = new tblUserAddress();

                    // Set the properties
                    newrow.Id = Guid.NewGuid();
                    newrow.UserId = userAddress.UserId;
                    newrow.Address = userAddress.Address;
                    newrow.City = userAddress.City;
                    newrow.State = userAddress.State;
                    newrow.ZipCode = userAddress.ZipCode;

                    // Do the Insert
                    dc.tblUserAddresses.Add(newrow);

                    // Commit the insert
                    return Convert.ToBoolean(dc.SaveChanges());
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool Insert(Guid userid, string address, string city, string state, string zipcode)
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    // Make a new row
                    tblUserAddress newrow = new tblUserAddress();

                    // Set the properties
                    newrow.Id = Guid.NewGuid();
                    newrow.UserId = userid;
                    newrow.Address = address;
                    newrow.City = city;
                    newrow.State = state;
                    newrow.ZipCode = zipcode;

                    // Do the Insert
                    dc.tblUserAddresses.Add(newrow);

                    // Commit the insert
                    return Convert.ToBoolean(dc.SaveChanges());
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int Update(Guid id, Guid userid, string address, string city, string state, string zipcode)
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    tblUserAddress updatedrow = dc.tblUserAddresses.FirstOrDefault(a => a.Id == id);

                    if (updatedrow != null)
                    {
                        updatedrow.UserId = userid;
                        updatedrow.Address = address;
                        updatedrow.City = city;
                        updatedrow.State = state;
                        updatedrow.ZipCode = zipcode;


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

        public static int Update(UserAddress userAddress)
        {
            try
            {
                using (AzureFoodOrderSystemEntities dc = new AzureFoodOrderSystemEntities())
                {
                    tblUserAddress updatedrow = dc.tblUserAddresses.FirstOrDefault(a => a.Id == userAddress.Id);

                    if (updatedrow != null)
                    {
                        updatedrow.UserId = userAddress.UserId;
                        updatedrow.Address = userAddress.Address;
                        updatedrow.City = userAddress.City;
                        updatedrow.State = userAddress.State;
                        updatedrow.ZipCode = userAddress.ZipCode;


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
                    tblUserAddress deletedrow = dc.tblUserAddresses.FirstOrDefault(a => a.Id == id);

                    if (deletedrow != null)
                    {
                        dc.tblUserAddresses.Remove(deletedrow);

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