using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfFynbusService.Entity_Framework.Implemented
{
    public abstract class RdgBase
    {
        protected WcfFynbusService.Entity_Framework.FynbusContext dbContext;

        public RdgBase()
        {
            this.dbContext = new FynbusContext();
        }
    }
}
