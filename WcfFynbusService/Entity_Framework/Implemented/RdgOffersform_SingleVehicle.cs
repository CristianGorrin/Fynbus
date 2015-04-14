using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfFynbusService.Entity_Framework.Implemented
{
    public class RdgOffersform_SingleVehicle : Implemented.RdgBase
    {

        public RdgOffersform_SingleVehicle()
            : base()
        {

        }

        ~RdgOffersform_SingleVehicle()
        {
            this.dbContext.Dispose();
        }

        public bool Add(int basicInformation, int wagonDetails, int price, string additionalInformation, int ownedBy)
        {
            try
            {
                this.dbContext.Offersform_SingleVehicle.Add(new Offersform_SingleVehicle() 
                { 
                    BasicInformation = basicInformation,
                    WagonDetails = wagonDetails,
                    Price = price,
                    AdditionalInformation = additionalInformation,
                    OwnedBy = ownedBy
                });

                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {
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

    }
}
