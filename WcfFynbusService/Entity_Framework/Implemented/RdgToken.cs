using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfFynbusService.Entity_Framework.Implemented
{
    public class RdgToken
    {
        private WcfFynbusService.Entity_Framework.FynbusContext dbContext;

        public RdgToken()
        {
            this.dbContext = new FynbusContext();
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

        public int RemoveAtUserId(int usersId)
        {
            int count = 0;
            try
            {
                foreach (var item in this.dbContext.Tokens)
                {
                    if (item.UsersID == usersId)
                    {
                        this.dbContext.Tokens.Remove(item);
                        count++;
                    }
                }

                this.dbContext.SaveChanges();
                return count;
            }
            catch (Exception)
            {
                return -1;
            }
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

        public Token FindBaseTokenSktring(string token)
        {
            try
            {
                return this.dbContext.Tokens.Single(x => x.TokenString == token);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ValidateToken(string token, string acc)
        {
            try
            {
                var obj = this.dbContext.Tokens.Single(x => x.TokenString == token & x.User.Account == acc);

                if (obj != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
