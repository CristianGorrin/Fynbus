using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfFynbusService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Login : Interfaces.ILogin
    {
        private const string TOKEN_BASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefgijkmnopqrstuvwxyz0123456789";

        private Entity_Framework.Implemented.RdgUser rdgUser;
        private Entity_Framework.Implemented.RdgToken rdgToken;


        public Login()
        {
            this.rdgUser = new Entity_Framework.Implemented.RdgUser();
            this.rdgToken = new Entity_Framework.Implemented.RdgToken();
        }

        public string LoginServices(string acc, string password)
        {
            var obj = this.rdgUser.Login(acc, password);

            if (obj != null)
            {
                this.rdgToken.RemoveAtUserId(obj.ID);

                string result = string.Empty;

                while (result == string.Empty)
                {
                    var random = new Random();
                    result = new string(
                        Enumerable.Repeat(TOKEN_BASE, 450)
                                  .Select(s => s[random.Next(s.Length)])
                                  .ToArray());

                    if (this.rdgToken.FindId(result) == null)
                    {
                        if (this.rdgToken.Add(obj.ID, result))
                        {
                            return result;
                        }
                        else
                        {
                            return "Login services failed";
                        }
                    }
                    else
                    {
                        result = string.Empty;
                    }
                }
            }
            else
            {
                return "Invalid";
            }

            return "Error";
        }

        public bool ValidateToken(string token, string acc)
        {
            return this.rdgToken.ValidateToken(token, acc);
        }

        public bool CreatedAccount(string accName, string password, string email)
        {
            return this.rdgUser.Add(accName, password, email);
        }

        public bool ValidateAccNewName(string name)
        {
            return this.rdgUser.NameInUse(name);
        }
    }
}
