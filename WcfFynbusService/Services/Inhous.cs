using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;

namespace WcfFynbusService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Inhous : Interfaces.IInhous
    {

        public string GetTest
        {
            get { return "test"; }
        }
    }
}
