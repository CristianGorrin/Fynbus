using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfFynbusService.DataInterfaces
{
    public class DataUser : Interface.EF_DataInterfaces.IUser
    {
        public int id
        {
            get; set;
        }

        public string Acc
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }
    }
}
