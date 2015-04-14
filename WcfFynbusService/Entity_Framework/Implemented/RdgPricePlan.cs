using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfFynbusService.Entity_Framework.Implemented
{
    public class RdgPricePlan
    {
        private WcfFynbusService.Entity_Framework.FynbusContext dbContext;

        public RdgPricePlan()
        {
            this.dbContext = WcfFynbusService.Entity_Framework.Implemented.DbContextFynbus.dbContext;
        }

        ~RdgPricePlan()
        {
            this.dbContext.Dispose();
        }

        public bool Add(decimal setUpFee, decimal hourlyRate, decimal hourlyDdownTime)
        {
            try 
	        {	        
		        var obj = new PricePlan();

                obj.SetUpFee = setUpFee;
                obj.HourlyRate = hourlyRate;
                obj.HourlyDdownTime = hourlyDdownTime;

                this.dbContext.PricePlans.Add(obj);
                this.dbContext.SaveChanges();
	        }
	        catch (Exception)
	        {
                return false;
	        }

            return true;
        }

        public bool Update(int id, decimal setUpFee, decimal hourlyRate, decimal hourlyDdownTime)
        {
            try 
	        {	        
		        var obj = this.dbContext.PricePlans.Single(x => x.ID == id);

                obj.SetUpFee = setUpFee;
                obj.HourlyRate = hourlyRate;
                obj.HourlyDdownTime = hourlyDdownTime;

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
		        this.dbContext.PricePlans.Remove(
                    this.dbContext.PricePlans.Single(x => x.ID == id));
                
                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public PricePlan Find(int id)
        {
            try
            {
                return this.dbContext.PricePlans.Single(x => x.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int? FindId(decimal setUpFee, decimal hourlyRate, decimal hourlyDdownTime)
        {
            try
            {
                return this.dbContext.PricePlans.First(x =>
                    x.SetUpFee == setUpFee & x.HourlyRate == hourlyRate & x.HourlyDdownTime == hourlyDdownTime).ID;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
