using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;

namespace WcfFynbusService.Interfaces
{
    [ServiceContract]
    public interface IInhous
    {
        [OperationContract]
        string GetOffers(string token, int index);
    }
}
