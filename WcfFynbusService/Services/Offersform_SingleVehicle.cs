using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;

namespace WcfFynbusService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Offersform_SingleVehicle : Interfaces.IOffersform_SingleVehicle
    {
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

                    if (!rdgWagone.Add(wagonGuaranteeId, registrationLetters, registrationNumbers, phoneNumber,
                        vehicleType, stairMachine, highchairs, homeWagon, tokenObj.UsersID))
                        return -1;

                    var obj = rdgWagone.FindId(wagonGuaranteeId, registrationLetters, registrationNumbers,
                        phoneNumber, vehicleType, stairMachine, highchairs, homeWagon, tokenObj.UsersID);

                    if (obj != null)
                    {
                        return obj.Value;
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

                    if (!rdg.Add(streetName, streetNumber, zipCode, city, municipality))
                        return -1;

                    var obj = rdg.FindID(streetName, streetNumber, zipCode, city, municipality);

                    if (obj != null)
                    {
                        return obj.Value;
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

                    if (!rdg.Add(WeekdaysID, WeekdaysEveningID, WeekendersHelligdageID))
                        return -1;

                    var obj = rdg.FindId(WeekdaysID, WeekdaysEveningID, WeekendersHelligdageID);

                    if (obj != null)
                    {
                        return obj.Value;
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

                    if (!rdg.Add(setUpFee, hourlyRate, hourlydDoenTime))
                        return -1;

                    var obj = rdg.FindId(setUpFee, hourlyRate, hourlydDoenTime);

                    if (obj != null)
                    {
                        return obj.Value;
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

                    if (!rdg.Add(basicInformationID, wagonDetailsID, priceID, addInfo, tokenObj.UsersID))
                        return -1;

                    var obj = rdg.FindID(basicInformationID, wagonDetailsID, priceID, addInfo, tokenObj.UsersID);

                    if (obj != null)
                    {
                        return obj.Value;
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
    }
}
