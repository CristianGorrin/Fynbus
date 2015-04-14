using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfFynbusService.Entity_Framework.Implemented
{
    public class RdgUser : Implemented.RdgBase
    {
        
        public RdgUser()
            : base()
        {

        }
                
        ~RdgUser()
        {
            this.dbContext.Dispose();
        }

        public bool Add(string accountName, string password, string email)
        {
            try 
	        {	        
		        var obj = new User();

                obj.Account = accountName;
                obj.Password = password;
                obj.Email = email;
                obj.UsersAccessLevels = 0;

                this.dbContext.Users.Add(obj);
                this.dbContext.SaveChanges();
	        }
	        catch (Exception)
	        {
                return false;
	        }

            return true;
        }

        public bool UpdateUsersAccessLevels(int id, byte usersAccessLevels)
        {
            try 
	        {	        
		        this.dbContext.Users.Single(x => x.ID == id).UsersAccessLevels = usersAccessLevels;
                this.dbContext.SaveChanges();
	        }
	        catch (Exception)
	        {
                return false;
	        }

            return true;
        }

        public bool Update(int id, string accountName, string password, string email)
        {
            try 
	        {	        
		        var obj = this.dbContext.Users.Single(x => x.ID == id);

                obj.Account = accountName;
                obj.Password = password;
                obj.Email = email;

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
		        this.dbContext.Users.Remove(this.dbContext.Users.Single(x => x.ID == id));
                this.dbContext.SaveChanges();
	        }
	        catch (Exception)
	        {
                return false;
	        }

            return true;
        }

        public User Find(int id)
        {
            try 
	        {
                return this.dbContext.Users.Single(x => x.ID == id);
	        }
	        catch (Exception)
	        {
                return null;
	        }
        }

        public int? FindId(string accountName, string password, string email)
        {
            try
            {
                return this.dbContext.Users.Single(x => 
                    x.Account == accountName & x.Password == password & x.Email == email).ID;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
