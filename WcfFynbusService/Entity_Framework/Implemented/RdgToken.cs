using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfFynbusService.Entity_Framework.Implemented
{
    public class RdgToken : Implemented.RdgBase
    {
        public RdgToken()
            : base()
        {

        }
        
        ~RdgToken()
        {
            this.dbContext.Dispose();
        }

        public bool Add(int usersId, string token)
        {
            try 
	        {	        
		        var obj = new Token();

                obj.UsersID = usersId;
                obj.TokenString = token;
                obj.CreateDate = DateTime.Now;
                
                this.dbContext.Tokens.Add(obj);
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
		        this.dbContext.Tokens.Remove(
                    this.dbContext.Tokens.Single(x => x.ID == id));
                
                this.dbContext.SaveChanges();
	        }
	        catch (Exception)
	        {
		        return false;
	        }

            return true;
        }

        public Token Find(int id)
        {
            try
            {
                return this.dbContext.Tokens.Single(x => x.ID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int? FindId(string token)
        {
            try
            {
                return this.dbContext.Tokens.Single(x => x.TokenString == token).ID;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
