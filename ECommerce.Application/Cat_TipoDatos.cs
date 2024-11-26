using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Cat_TipoDatos
    {
        Data.Cat_TipoDatos _cat_Cat_TipoDatos = new Data.Cat_TipoDatos();
        public List<Models.Cat_TipoDatos> Cat_FlujoBase_Listar()
        {
            return _cat_Cat_TipoDatos.Cat_TipoDatos_Listar();
        }
    }
}
