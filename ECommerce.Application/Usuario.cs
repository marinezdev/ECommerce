using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Usuario
    {
        Data.Usuario _Usuario = new Data.Usuario();

        public Models.Usuarios Iniciar(Models.Usuarios usuarios)
        {
            Models.Usuarios user = _Usuario.Usuario_Selecionar_Pas_US(usuarios);
            return user;
        }

        public Models.Usuarios coo_Session_Seleccionar(string clave)
        {
            Models.Usuarios usuario = _Usuario.coo_Session_Seleccionar(clave);
            return usuario;
        }

        public Models.Usuarios Consulta_Usuario_Nombre(int IdUsuario)
        {
            Models.Usuarios usuario = _Usuario.Consulta_Usuario_Nombre(IdUsuario);
            return usuario;
        }

        

    }
}
