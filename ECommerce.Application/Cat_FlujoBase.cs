using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Cat_FlujoBase
    {
        Data.Cat_FlujoBase _cat_Cat_FlujoBase = new Data.Cat_FlujoBase();
        public List<Models.Cat_FlujoBase> Cat_FlujoBase_Listar(Models.Flujo flujo)
        {
            return _cat_Cat_FlujoBase.Cat_FlujoBase_Listar(flujo);
        }
    }
}
