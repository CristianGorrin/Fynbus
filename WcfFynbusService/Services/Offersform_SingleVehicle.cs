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
        public int NewBasicInformation(string token, string name, int cvr, string nameAlt)
        {
            try
            {
                var tokenDbContext = new Entity_Framework.Implemented.RdgToken();
                int? tokenID = tokenDbContext.FindId(token);

                if (tokenID != null)
                {
                    var bi = new Entity_Framework.Implemented.RdgBasicInformation();

                    if  (bi.Add(tokenDbContext.Find((int)tokenID).UsersID, name, cvr, nameAlt))
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

        public int NewWagone(string token, int? wagonGuaranteeId, string registrationLetters, int registrationNumbers, int phoneNumber, byte vehicleType, byte? stairMachine, byte? highchairs, int? homeWagon, int owneBy)
        {
            throw new NotImplementedException();
        }

        public int NewHomeWagon(string token, string streetName, short streetNumber, short zipCode, string city, string municipality)
        {
            throw new NotImplementedException();
        }

        public int NewPrice(string token, int WeekdaysID, int WeekdaysEveningID, int WeekendersHelligdageID, decimal StairMachine)
        {
            throw new NotImplementedException();
        }

        public int NewPricePlan(string token, decimal setUpFee, decimal hourlyRate, decimal hourlydDoenTime)
        {
            throw new NotImplementedException();
        }

        public int NewOffersform_SingleVehicle(string token, int basicInformationID, int wagonDetailsID, int priceID, string addInfo)
        {
            throw new NotImplementedException();
        }
    }
}
