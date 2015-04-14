using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfFynbusService.Entity_Framework.Implemented
{
    public class RdgHomeWagoncs : Implemented.RdgBase
    {
        public RdgHomeWagoncs()
            : base()
        {

        }

        ~RdgHomeWagoncs()
        {
            this.dbContext.Dispose();
        }

        public bool New(string streetName, short streetNumber, short zipCode, string city, string municipality)
        {
            try
            {
                var newHome = new HomeWagon();

                newHome.StreetName = streetName;
                newHome.StreetNumber = streetNumber;
                newHome.ZipCode = zipCode;
                newHome.City = city;
                newHome.Municipality = municipality;

                this.dbContext.HomeWagons.Add(newHome);
                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Update(int id, string streetName, short streetNumber, short zipCode, string city, string municipality)
        {
            try
            {
                var obj = this.dbContext.HomeWagons.SingleOrDefault(x => x.ID == id);

                obj.StreetName = streetName;
                obj.StreetNumber = streetNumber;
                obj.ZipCode = zipCode;
                obj.City = city;
                obj.Municipality = municipality;

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
                this.dbContext.HomeWagons.Remove(this.dbContext.HomeWagons.SingleOrDefault(x => x.ID == id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public int? FindID(string streetName, short streetNumber, short zipCode, string city, string municipality)
        {
            try
            {
                var obj = this.dbContext.HomeWagons.FirstOrDefault(x =>
                    x.StreetName == streetName & x.StreetNumber == streetNumber & x.ZipCode == zipCode &
                    x.City == city & x.Municipality == municipality);

                return obj.ID;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public HomeWagon Find(int id)
        {
            try
            {
                return this.dbContext.HomeWagons.FirstOrDefault(x => x.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
