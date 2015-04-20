using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;

namespace WcfFynbusService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Offersform_SingleVehicle : Interfaces.IOffersform_SingleVehicle
    {
        #region Add new
        private Entity_Framework.Token GetTokenObj(string token)
        {
            var tokenDbContext = new Entity_Framework.Implemented.RdgToken();
            return tokenDbContext.FindBaseTokenSktring(token);
        }

        public int NewBasicInformation(string token, string name, int cvr, string nameAlt)
        {
            try
            {
                var tokenObj = GetTokenObj(token);

                if (tokenObj != null)
                {
                    var bi = new Entity_Framework.Implemented.RdgBasicInformation();

                    if (bi.FindByUsersId(tokenObj.UsersID) != null)
                        return -1;

                    if (bi.Add(tokenObj.UsersID, name, cvr, nameAlt))
                    {
                        Entity_Framework.BasicInformation obj = null;
                        bi.FindID(name, cvr, nameAlt, out obj);

                        return obj.ID;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int NewWagone(string token, int? wagonGuaranteeId, string registrationLetters, 
            int registrationNumbers, int phoneNumber, byte vehicleType, byte? stairMachine, byte? highchairs, 
            int? homeWagon, int owneBy)
        {
            try
            {
                var tokenObj = GetTokenObj(token);

                if (tokenObj != null)
                {
                    var rdgWagone = new Entity_Framework.Implemented.RdgWagonDetail();
                    Entity_Framework.WagonDetail obj = null;

                    if (!rdgWagone.Add(wagonGuaranteeId, registrationLetters, registrationNumbers, phoneNumber,
                        vehicleType, stairMachine, highchairs, homeWagon, tokenObj.UsersID, out obj))
                        return -1;

                    if (obj != null)
                    {
                        return obj.ID;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int NewHomeWagon(string token, string streetName, short streetNumber, short zipCode, 
            string city, string municipality)
        {
            try
            {
                var tokenObj = GetTokenObj(token);

                if (tokenObj != null)
                {
                    var rdg = new Entity_Framework.Implemented.RdgHomeWagoncs();

                    Entity_Framework.HomeWagon obj = null;

                    if (!rdg.Add(streetName, streetNumber, zipCode, city, municipality, out obj))
                        return -1;

                    if (obj != null)
                    {
                        return obj.ID;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int NewPrice(string token, int WeekdaysID, int WeekdaysEveningID, int WeekendersHelligdageID, 
            decimal StairMachine)
        {
            try
            {
                var tokenObj = GetTokenObj(token);

                if (tokenObj != null)
                {
                    var rdg = new Entity_Framework.Implemented.RdgPrice();
                    Entity_Framework.Price obj = null;

                    if (!rdg.Add(WeekdaysID, WeekdaysEveningID, WeekendersHelligdageID, out obj))
                        return -1;

                    if (obj != null)
                    {
                        return obj.ID;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int NewPricePlan(string token, decimal setUpFee, decimal hourlyRate, decimal hourlydDoenTime)
        {
            try
            {
                var tokenObj = GetTokenObj(token);

                if (tokenObj != null)
                {
                    var rdg = new Entity_Framework.Implemented.RdgPricePlan();
                    Entity_Framework.PricePlan obj = null;

                    if (!rdg.Add(setUpFee, hourlyRate, hourlydDoenTime, out obj))
                        return -1;

                    if (obj != null)
                    {
                        return obj.ID;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int NewOffersform_SingleVehicle(string token, int basicInformationID, int wagonDetailsID, 
            int priceID, string addInfo)
        {
            try
            {
                var tokenObj = GetTokenObj(token);

                if (tokenObj != null)
                {
                    var rdg = new Entity_Framework.Implemented.RdgOffersform_SingleVehicle();
                    Entity_Framework.Offersform_SingleVehicle obj = null;

                    if (!rdg.Add(basicInformationID, wagonDetailsID, priceID, addInfo, tokenObj.UsersID, out obj))
                        return -1;


                    if (obj != null)
                    {
                        return obj.ID;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }
        #endregion

        #region Get
        public Interface.EF_DataInterfaces.IUser GetUserInfo(string token)
        {
            try
            {
                var tokenObj = GetTokenObj(token);

                if (tokenObj != null)
                {
                    var obj = tokenObj.User;

                    return new DataInterfaces.DataUser()
                    {
                        Acc = obj.Account,
                        Email = obj.Email,
                        id = obj.ID
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Interface.EF_DataInterfaces.IBasicInformation GetBasicInformation(string token)
        {
            try
            {
                var tokenObj = GetTokenObj(token);

                var rdg = new Entity_Framework.Implemented.RdgBasicInformation();
                var bi = rdg.FindByUsersId(tokenObj.UsersID);

                return new DataInterfaces.DataBasicInformation()
                {
                    AltName = bi.NameSecondary,
                    CVR = bi.CVR,
                    ID = bi.ID,
                    Name = bi.Name
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Interface.EF_DataInterfaces.IOffersform_SingleVehicle> GetOffersforms(string token)
        {
            var list = new List<Interface.EF_DataInterfaces.IOffersform_SingleVehicle>();
            try
            {
                var tokenObj = GetTokenObj(token);
                var rdg = new Entity_Framework.Implemented.RdgOffersform_SingleVehicle();

                foreach (var item in rdg.GetListByUserID(tokenObj.UsersID))
                {
                    list.Add(new DataInterfaces.DataOffersform_SingleVehicle() 
                    {
                        AdditionalInformation = item.AdditionalInformation,
                        City = item.WagonDetail.ObjHomeWagon.City,
                        GuaranteeID = item.WagonDetail.Guarantee,
                        Highchairs = item.WagonDetail.Highchairs,
                        ID = item.ID,
                        Municipality = item.WagonDetail.ObjHomeWagon.Municipality,
                        PhoneNumber = item.WagonDetail.PhoneNumber,
                        RegistrationLetters = item.WagonDetail.RegistrationLetters,
                        RegistrationNumbers = item.WagonDetail.RegistrationNumbers,
                        StairMachine = item.Prices.StairMachine.Value,
                        StairMachineType = item.WagonDetail.StairMachine,
                        StreetName = item.WagonDetail.ObjHomeWagon.StreetName,
                        StreetNumber = item.WagonDetail.ObjHomeWagon.StreetNumber,
                        VehicleType = item.WagonDetail.VehicleType,
                        Weekdays = new decimal[] { item.Prices.ObjWeekdays.SetUpFee, item.Prices.ObjWeekdays.HourlyRate, item.Prices.ObjWeekdays.HourlyDdownTime },
                        WeekdaysEvening = new decimal[] { item.Prices.ObjWeekdaysEvening.SetUpFee, item.Prices.ObjWeekdaysEvening.HourlyRate, item.Prices.ObjWeekdaysEvening.HourlyDdownTime },
                        WeekendersHelligdage = new decimal[] { item.Prices.ObjWeekendersHelligdage.SetUpFee, item.Prices.ObjWeekendersHelligdage.HourlyRate, item.Prices.ObjWeekendersHelligdage.HourlyDdownTime },
                        ZipCode = item.WagonDetail.ObjHomeWagon.ZipCode
                    });
                }

                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Update
        public bool UpdateBasicInfo(string token, string name, int cvr, string altName)
        {
            if (name == string.Empty || cvr < 10000000)
                return false;

            try
            {
                var tokenObj = GetTokenObj(token);

                if (tokenObj != null)
                {
                    var rdg = new Entity_Framework.Implemented.RdgBasicInformation();

                    var obj = rdg.FindByUsersId(tokenObj.UsersID);

                    if (obj != null)
                    {
                        rdg.Update(obj.ID, name, cvr, altName);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateOfferFrom(string token, int id, string addInfo)
        {
            try
            {
                var tokenObj = GetTokenObj(token);

                if (token != null)
                {
                    var rdg = new Entity_Framework.Implemented.RdgOffersform_SingleVehicle();

                    var obj = rdg.Find(id);

                    if (obj != null)
                    {
                        if (obj.OwnedBy == tokenObj.UsersID)
                        {
                            obj.AdditionalInformation = addInfo;
                            rdg.Save();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateUser(string pass, string user, string newPass, string newEmail)
        {
            try
            {
                var rdg = new Entity_Framework.Implemented.RdgUser();

                if (!rdg.UpdatePassAndEmail(user, pass, newPass, newEmail))
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateWagonDetail(string token, int id, int? guarantee, string registrationLetters, 
            int? registrationNumbers, int phoneNumber, string streetName, short streetNumber, short zipCode, 
            string city, string municipality)
        {
            try
            {
                var tokenObj = GetTokenObj(token);

                if (tokenObj != null)
                {
                    var rdgWagon = new Entity_Framework.Implemented.RdgWagonDetail();

                    var obj = rdgWagon.Find(id);

                    if (obj != null)
                    {
                        if (obj.OwnedBy == tokenObj.UsersID)
                        {

                            if (guarantee == -1)
                            {
                                obj.Guarantee = null;
                            }
                            else
                            {
                                obj.Guarantee = guarantee;
                            }

                            if (registrationNumbers == -1)
                            {
                                obj.RegistrationNumbers = null;
                            }
                            else
                            {
                                obj.RegistrationNumbers = registrationNumbers;
                            }

                            obj.RegistrationLetters = registrationLetters;
                            obj.PhoneNumber = phoneNumber;
                            obj.ObjHomeWagon.StreetName = streetName;
                            obj.ObjHomeWagon.StreetNumber = streetNumber;
                            obj.ObjHomeWagon.ZipCode = zipCode;
                            obj.ObjHomeWagon.City = city;
                            obj.ObjHomeWagon.Municipality = municipality;

                            if (!rdgWagon.Save())
                                return false;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}
