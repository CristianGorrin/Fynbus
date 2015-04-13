using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfFynbusService
{
    public class Login : Interfaces.ILogin
    {
        public string LoginServices(string acc, string password)
        {
            throw new NotImplementedException();
        }

        public bool ValidateToken(string token, string acc)
        {
            throw new NotImplementedException();
        }
    }
}
