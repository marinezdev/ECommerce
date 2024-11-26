using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Usuarios_Invitado
    {
        Data.Usuarios_Invitado _usuarios_Invitado = new Data.Usuarios_Invitado();
        public Models.Cliente Usuarios_Invitado_Agregar(string Clave, Models.Usuarios_Invitado usuarios_Invitado)
        {
            return _usuarios_Invitado.Usuarios_Invitado_Agregar(Clave, usuarios_Invitado);
        }
    }
}
