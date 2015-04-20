using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfFynbusService.Entity_Framework.Implemented
{
    public class RdgWagonDetail
    {
        private WcfFynbusService.Entity_Framework.FynbusContext dbContext;

        public RdgWagonDetail() 
        {
            this.dbContext = new FynbusContext();
        }
                        
        ~RdgWagonDetail()
        {
            this.dbContext.Dispose();
        }


        public bool Add(int? guarantee, string registrationLetters, int registrationNumbers, int phoneNumber,
            byte vehicleType, byte? stairMachine, byte? highchairs, int? homeWagon, int ownedBy, out WagonDetail newObj)
        {
            try 
	        {	        
		        var obj = new WagonDetail();

                if (guarantee == -1)
                {
                    obj.Guarantee = null;
                }
                else
                {
                    obj.Guarantee = guarantee;
                }

                if (registrationLetters == null)
                {
                    obj.RegistrationLetters = string.Empty;
                }
                else
                {
                    obj.RegistrationLetters = registrationLetters;
                }

                if (registrationNumbers == -1)
                {
                    obj.RegistrationNumbers = null;
                }
                else
                {
                    obj.RegistrationNumbers = registrationNumbers;
                }

                obj.PhoneNumber = phoneNumber;
                obj.VehicleType = vehicleType;
                obj.Highchairs = highchairs;
                obj.StairMachine = stairMachine;
                obj.HomeWagon = homeWagon;
                obj.OwnedBy = ownedBy;

                this.dbContext.WagonDetails.Add(obj);
                this.dbContext.SaveChanges();
                newObj = obj;
	        }
	        catch (Exception)
	        {
                newObj = null;
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

                if (homeWagon == -1)
                {
                    obj.HomeWagon = null;
                }
                else
                {
                    obj.HomeWagon = homeWagon;
                }

                obj.RegistrationLetters = registrationLetters;
                obj.PhoneNumber = phoneNumber;
                obj.VehicleType = vehicleType;

                obj.StairMachine = stairMachine;
                obj.Highchairs = highchairs;
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

        public int? FindId(int? guarantee, string registrationLetters, int registrationNumbers,
            int phoneNumber, byte vehicleType, byte? stairMachine, byte? highchairs, int? homeWagon, int ownedBy)
        {
            try
            {
                return this.dbContext.WagonDetails.First(x => 
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

        public bool Save()
        {
            try
            {
                this.dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;   
            }
        }
    }
}
