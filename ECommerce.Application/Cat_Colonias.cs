using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Cat_Colonias
    {
        Data.Cat_Colonias _cat_Colonias = new Data.Cat_Colonias();
        public List<Models.Cat_Colonias> Cat_Colonias_Seleccionar(int Id)
        {
            return _cat_Colonias.Cat_Colonias_Seleccionar(Id);
        }
    }
}
