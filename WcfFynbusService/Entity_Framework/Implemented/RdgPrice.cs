using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfFynbusService.Entity_Framework.Implemented
{
    public class RdgPrice : Implemented.RdgBase
    {

        public RdgPrice()
            : base()
        {

        }

        ~RdgPrice()
        {
            this.dbContext.Dispose();
        }

        public bool Add(int weekdays, int weekdaysEvening, int weekendersHelligdage)
        {
            try 
	        {
                var obj = new Price();

                obj.Weekdays = weekdays;
                obj.WeekdaysEvening = weekdaysEvening;
                obj.WeekendersHelligdage = weekendersHelligdage;

                this.dbContext.Prices.Add(obj);
                this.dbContext.SaveChanges();
	        }
	        catch (Exception)
	        {
                return false;
	        }

            return true;
        }

        public bool Update(int id, int weekdays, int weekdaysEvening, int weekendersHelligdage)
        {
            try
            {
                var obj = this.dbContext.Prices.Single(x => x.ID == id);

                obj.Weekdays = weekdays;
                obj.WeekdaysEvening = weekdaysEvening;
                obj.WeekendersHelligdage = weekendersHelligdage;

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
                this.dbContext.Prices.Remove(
                    this.dbContext.Prices.Single(x => x.ID == id));
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }

        public Price Find(int id)
        {
            try
            {
                return this.dbContext.Prices.Single(x => x.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int? FindId(int weekdays, int weekdaysEvening, int weekendersHelligdage)
        {
            try
            {
                return this.dbContext.Prices.Single(x =>
                    x.Weekdays == weekdays & x.WeekdaysEvening == weekdaysEvening &
                    x.WeekendersHelligdage == weekendersHelligdage).ID;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
