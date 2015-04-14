using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfFynbusService.Entity_Framework.Implemented
{
    public class RdgWagonDetail : Implemented.RdgBase
    {
        public RdgWagonDetail() 
            : base()
        {

        }
                        
        ~RdgWagonDetail()
        {
            this.dbContext.Dispose();
        }


        public bool Add(int guarantee, string registrationLetters, int registrationNumbers, int phoneNumber,
            byte vehicleType, byte? stairMachine, byte? highchairs, int homeWagon, int ownedBy)
        {
            try 
	        {	        
		        var obj = new WagonDetail();
                obj.Guarantee = guarantee;
                obj.RegistrationLetters = registrationLetters;
                obj.RegistrationNumbers = registrationNumbers;
                obj.PhoneNumber = phoneNumber;
                obj.VehicleType = vehicleType;
                obj.StairMachine = stairMachine;
                obj.Highchairs = highchairs;
                obj.HomeWagon = homeWagon;
                obj.OwnedBy = ownedBy;

                this.dbContext.WagonDetails.Add(obj);
                this.dbContext.SaveChanges();
	        }
	        catch (Exception)
	        {
                return false;
	        }

            return true;
        }

        public bool Update(int id, int guarantee, string registrationLetters, int registrationNumbers, 
            int phoneNumber, byte vehicleType, byte? stairMachine, byte? highchairs, int homeWagon, int ownedBy)
        {
            try 
            {	        
		        var obj = this.dbContext.WagonDetails.SingleOrDefault(x => x.ID == id);

                obj.Guarantee = guarantee;
                obj.RegistrationLetters = registrationLetters;
                obj.RegistrationNumbers = obj.RegistrationNumbers;
                obj.PhoneNumber = phoneNumber;
                obj.VehicleType = vehicleType;
                obj.StairMachine = stairMachine;
                obj.Highchairs = highchairs;
                obj.HomeWagon = homeWagon;
                obj.OwnedBy = ownedBy;

                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {
		        return false;
            }

            return true;
        }

        public bool Remove(int id)
        {
            try 
            {	        
		        this.dbContext.WagonDetails.Remove(
                    this.dbContext.WagonDetails.SingleOrDefault(x => x.ID == id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public WagonDetail Find(int id)
        {
            try
            {
                return this.dbContext.WagonDetails.SingleOrDefault(x => x.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int? FindId(int guarantee, string registrationLetters, int registrationNumbers,
            int phoneNumber, byte vehicleType, byte? stairMachine, byte? highchairs, int homeWagon, int ownedBy)
        {
            try
            {
                return this.dbContext.WagonDetails.FirstOrDefault(x => 
                    x.Guarantee == guarantee & x.RegistrationLetters == registrationLetters &
                    x.RegistrationNumbers == registrationNumbers & x.PhoneNumber == phoneNumber &
                    x.VehicleType == vehicleType & x.StairMachine == stairMachine & x.Highchairs == highchairs &
                    x.HomeWagon == homeWagon & x.OwnedBy == ownedBy).ID;
                }
            catch (Exception)
            {
                return null;   
            }
        }
    }
}
