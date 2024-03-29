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
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {
                    List<UserAddress> results = new List<UserAddress>();
                    dc.tblUserAddresses.ToList().ForEach(p => results.Add(new UserAddress
                    {
                        Id = p.Id,
                        UserId = p.UserId,
                        Address = p.Address,
                        City = p.City,
                        StateId = p.StateId,
                        StateName = LoadStateById(p.StateId).Name,
                        StateAbbreviation = LoadStateById(p.StateId).Abbreviation,
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

        //public static List<StateId> LoadStateIds()
        //{
        //    try
        //    {
        //        using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
        //        {
        //            List<StateId> results = new List<StateId>();
        //            dc.tblStateIds.ToList().ForEach(s => results.Add(new StateId
        //            {
        //                Id = s.Id,
        //                Name = s.Name
        //            }));

        //            return results;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static UserAddress LoadById(Guid id)
        {
            try
            {
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
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
                            StateId = UserAddressRow.StateId,
                            StateName = LoadStateById(UserAddressRow.StateId).Name,
                            StateAbbreviation = LoadStateById(UserAddressRow.StateId).Abbreviation,
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
        public static List<State> LoadStates()
        {
            try
            {
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {
                    List<State> results = new List<State>();

                    dc.tblStates.ToList().ForEach(s => results.Add(new State
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Abbreviation = s.Abbreviation
                    }));

                    return results;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static State LoadStateById(int id)
        {
            try
            {
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {
                    tblState StateRow = dc.tblStates.FirstOrDefault(a => a.Id == id);

                    if (StateRow != null)
                    {
                        return new State
                        {
                            Id = StateRow.Id,
                            Abbreviation = StateRow.Abbreviation,
                            Name = StateRow.Name

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

        public static State LoadStateByAbbreviation(string abb)
        {
            try
            {
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {
                    tblState StateRow = dc.tblStates.FirstOrDefault(a => a.Abbreviation == abb);

                    if (StateRow != null)
                    {
                        return new State
                        {
                            Id = StateRow.Id,
                            Abbreviation = StateRow.Abbreviation,
                            Name = StateRow.Name

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
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
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
                        StateId = p.StateId,
                        StateName = LoadStateById(p.StateId).Name,
                        StateAbbreviation = LoadStateById(p.StateId).Abbreviation,
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
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
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
                            StateId = row.StateId,
                            StateName = LoadStateById(row.StateId).Name,
                            StateAbbreviation = LoadStateById(row.StateId).Abbreviation,
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
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {
                    // Make a new row
                    tblUserAddress newrow = new tblUserAddress();

                    State newstate = new State();
                    //newstate.Id = LoadStateByAbbreviation(userAddress.StateAbbreviation).Id;    // This is so the user will only need to enter WI.
                    
                    // Set the properties
                    newrow.Id = Guid.NewGuid();
                    newrow.UserId = userAddress.UserId;
                    newrow.Address = userAddress.Address;
                    newrow.City = userAddress.City;
                    newrow.StateId = userAddress.StateId;
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

        public static bool Insert(Guid userid, string address, string city, string stateAbbreviation, string zipcode)
        {
            try
            {
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {
                    // Make a new row
                    tblUserAddress newrow = new tblUserAddress();

                    State newstate = new State();
                    newstate.Id = LoadStateByAbbreviation(stateAbbreviation).Id;    // This is so the user will only need to enter WI.

                    // Set the properties
                    newrow.Id = Guid.NewGuid();
                    newrow.UserId = userid;
                    newrow.Address = address;
                    newrow.City = city;
                    newrow.StateId = newstate.Id;
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

        public static int Update(Guid id, Guid userid, string address, string city, string stateAbbreviation, string zipcode)
        {
            try
            {
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {
                    tblUserAddress updatedrow = dc.tblUserAddresses.FirstOrDefault(a => a.Id == id);



                    if (updatedrow != null)
                    {
                        State newstate = new State();
                        newstate.Id = LoadStateByAbbreviation(stateAbbreviation).Id;    // This is so the user will only need to enter WI.

                        updatedrow.UserId = userid;
                        updatedrow.Address = address;
                        updatedrow.City = city;
                        updatedrow.StateId = newstate.Id;
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
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
                {
                    tblUserAddress updatedrow = dc.tblUserAddresses.FirstOrDefault(a => a.Id == userAddress.Id);

                    if (updatedrow != null)
                    {
                        State newstate = new State();
                        //newstate.Id = LoadStateByAbbreviation(userAddress.StateAbbreviation).Id;    // This is so the user will only need to enter WI.

                        updatedrow.UserId = userAddress.UserId;
                        updatedrow.Address = userAddress.Address;
                        updatedrow.City = userAddress.City;
                        updatedrow.StateId = userAddress.StateId;
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
                using (FoodOrderSystemEntities dc = new FoodOrderSystemEntities())
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