using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;

namespace WcfFynbusService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Inhous : Interfaces.IInhous
    {
        public string GetOffers(string token, int index)
        {
            try
            {
                var _rdgToken = new Entity_Framework.Implemented.RdgToken();
                var tokenObj = _rdgToken.FindBaseTokenSktring(token);

                if (tokenObj != null && tokenObj.User.UsersAccessLevels >= 1)
                {
                    var dbContext = new Entity_Framework.FynbusContext();

                    var item = dbContext.Offersform_SingleVehicle.Single(x => x.ID == index);

                    return item.AdditionalInformation + ";" + 
                       item.ObjBasicInformation.NameSecondary + ";" +
                       item.WagonDetail.ObjHomeWagon.City + ";" + 
                       item.ObjBasicInformation.CVR + ";" +
                       item.WagonDetail.Guarantee + ";" + 
                       item.WagonDetail.Highchairs + ";" + 
                       item.ID + ";" +
                       item.WagonDetail.ObjHomeWagon.Municipality + ";" +
                       item.ObjBasicInformation.Name + ";" +
                       item.WagonDetail.PhoneNumber + ";" + 
                       item.WagonDetail.RegistrationLetters + " " + item.WagonDetail.RegistrationNumbers.ToString() + ";" +
                       item.Prices.StairMachine + ";" + 
                       item.WagonDetail.StairMachine + ";" + 
                       item.WagonDetail.ObjHomeWagon.StreetName + ";" +
                       item.WagonDetail.ObjHomeWagon.StreetNumber + ";" + 
                       item.WagonDetail.VehicleType + ";" +
                       item.Prices.ObjWeekdays.SetUpFee + ";" + 
                       item.Prices.ObjWeekdays.HourlyRate + ";" +
                       item.Prices.ObjWeekdays.HourlyDdownTime + ";" + 
                       item.Prices.ObjWeekdaysEvening.SetUpFee + ";" +
                       item.Prices.ObjWeekdaysEvening.HourlyRate + ";" + 
                       item.Prices.ObjWeekdaysEvening.HourlyDdownTime + ";" +
                       item.Prices.ObjWeekendersHelligdage.SetUpFee + ";" + 
                       item.Prices.ObjWeekendersHelligdage.HourlyRate + ";" +
                       item.Prices.ObjWeekendersHelligdage.HourlyDdownTime + ";" + 
                       item.WagonDetail.ObjHomeWagon.ZipCode;
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
    }
}
