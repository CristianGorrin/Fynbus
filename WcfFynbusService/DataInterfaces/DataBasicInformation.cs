using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfFynbusService.DataInterfaces
{
    public class DataBasicInformation : Interface.EF_DataInterfaces.IBasicInformation
    {
        public int ID
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public int CVR
        {
            get; set;
        }

        public string AltName
        {
            get; set;
        }
    }
}
