using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class EtapasUsuario
    {
        Data.EtapasUsuario _EtapasUsuario = new Data.EtapasUsuario();
        public List<Models.EtapasUsuario> Usuarios_listar_Asignacion(Models.EtapasUsuario etapasUsuario)
        {
            return _EtapasUsuario.Usuarios_listar_Asignacion(etapasUsuario);
        }

        public Models.Cat_FlujoBase EtapasUsuarios_Agregar(Models.Cat_FlujoBase cat_FlujoBase)
        {
            return _EtapasUsuario.EtapasUsuarios_Agregar(cat_FlujoBase);
        }
    }
}
