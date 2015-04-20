using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfFynbusService.Entity_Framework.Implemented
{
    public class RdgBasicInformation
    {
        private WcfFynbusService.Entity_Framework.FynbusContext dbContext;

        public RdgBasicInformation()
        {
            this.dbContext = new FynbusContext();
        }

        ~RdgBasicInformation()
        {
            this.dbContext.Dispose();
        }

        public bool Add(int usersID, string name, int cvr, string nameSecondary)
        {
            try
            {
                var obj = new BasicInformation();
                obj.Name = name;
                obj.CVR = cvr;
                obj.NameSecondary = nameSecondary;
                obj.OwnedBy = usersID;

                this.dbContext.BasicInformations.Add(obj);
                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Update(int id, string name, int cvr, string nameSecondary)
        {
            try
            {
                var obj = this.dbContext.BasicInformations.SingleOrDefault(x => x.ID == id);

                obj.Name = name;
                obj.CVR = cvr;
                obj.NameSecondary = nameSecondary;

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
                this.dbContext.BasicInformations.Remove(
                    this.dbContext.BasicInformations.SingleOrDefault(x => x.ID == id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public BasicInformation Find(int id)
        {
            try
            {
                return this.dbContext.BasicInformations.SingleOrDefault(x => x.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public BasicInformation FindByUsersId(int usersId)
        { 
            try
            {
                return this.dbContext.BasicInformations.Single(x => x.ObjUser.ID == usersId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int? FindID(string name, int cvr, string nameSecondary, out BasicInformation obj)
        {
            try
            {
                obj = this.dbContext.BasicInformations.First(
                    x => x.Name == name & x.CVR == cvr & x.NameSecondary == nameSecondary);

                return obj.ID;
            }
            catch (Exception)
            {
                obj = null;
                return null;
            }
        }
    }
}
