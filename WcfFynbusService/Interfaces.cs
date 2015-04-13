using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfFynbusService.Interfaces
{
    [ServiceContract]
    public interface ILogin
    {
        [OperationContract]
        string LoginServices(string acc, string password);

        [OperationContract]
        bool ValidateToken(string token, string acc);
    }
}
