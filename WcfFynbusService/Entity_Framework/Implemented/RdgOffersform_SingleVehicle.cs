using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfFynbusService.Entity_Framework.Implemented
{
    public class RdgOffersform_SingleVehicle
    {
        private WcfFynbusService.Entity_Framework.FynbusContext dbContext;

        public RdgOffersform_SingleVehicle()
        {
            this.dbContext = new FynbusContext();
        }

        ~RdgOffersform_SingleVehicle()
        {
            this.dbContext.Dispose();
        }

        public bool Add(int basicInformation, int wagonDetails, int price, string additionalInformation, int ownedBy, out Offersform_SingleVehicle newObj)
        {
            try
            {
                var obj = new Offersform_SingleVehicle()
                {
                    BasicInformation = basicInformation,
                    WagonDetails = wagonDetails,
                    Price = price,
                    AdditionalInformation = additionalInformation,
                    OwnedBy = ownedBy
                };
                this.dbContext.Offersform_SingleVehicle.Add(obj);

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

        public bool Update(int id, int basicInformation, int wagonDetails, int price, string additionalInformation, int ownedBy)
        {
            try
            {
                var obj = this.dbContext.Offersform_SingleVehicle.SingleOrDefault(x => x.ID == id);

                obj.BasicInformation = basicInformation;
                obj.WagonDetails = wagonDetails;
                obj.Price = price;
                obj.AdditionalInformation = additionalInformation;
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
                this.dbContext.Offersform_SingleVehicle.Remove(
                    this.dbContext.Offersform_SingleVehicle.SingleOrDefault(x => x.ID == id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public int? FindID(int basicInformation, int wagonDetails, int price, string additionalInformation, int ownedBy)
        {
            try
            {
                return this.dbContext.Offersform_SingleVehicle.FirstOrDefault(x =>
                    x.BasicInformation == basicInformation & x.WagonDetails == wagonDetails & x.Price == price &
                    x.AdditionalInformation == additionalInformation & x.OwnedBy == ownedBy).ID;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Offersform_SingleVehicle Find(int id)
        {
            try
            {
                return this.dbContext.Offersform_SingleVehicle.SingleOrDefault(x => x.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Save()
        {
            this.dbContext.SaveChanges();
        }

        public List<Offersform_SingleVehicle> GetListByUserID(int id)
        {
            var list = new List<Offersform_SingleVehicle>();
            
            try
            {
                foreach (var item in this.dbContext.Offersform_SingleVehicle.ToList())
                {
                    if (item.OwnedBy == id)
                    {
                        list.Add(item);
                    }
                }    

                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
