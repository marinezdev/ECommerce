using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Etapas
    {
        Data.Etapas _EtapasUsuario = new Data.Etapas();
        public Models.Cat_FlujoBase Etapas_Agregar(Models.Cat_FlujoBase cat_FlujoBase)
        {
            return _EtapasUsuario.Etapas_Agregar(cat_FlujoBase);
        }
    }
}
