using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;

namespace WcfFynbusService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Admin : Interfaces.IAdmin
    {

        public string Test
        {
            get { return "test"; }
        }
    }
}
