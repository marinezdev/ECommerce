using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Cat_Estados
    {
        Data.Cat_Estados _cat_Estados = new Data.Cat_Estados();
        public List<Models.Cat_Estados> Cat_Estados_Seleccionar()
        {
            return _cat_Estados.Cat_Estados_Seleccionar();
        }
    }
}
