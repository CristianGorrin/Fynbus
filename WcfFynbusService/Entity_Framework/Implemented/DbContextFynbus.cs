using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfFynbusService.Entity_Framework.Implemented
{
    public static class DbContextFynbus
    {
        public static WcfFynbusService.Entity_Framework.FynbusContext dbContext = new FynbusContext();
    }
}
