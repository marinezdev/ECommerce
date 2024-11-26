using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Usuarios_Direcciones
    {
        Data.Usuarios_Direcciones _usuarios_Direcciones = new Data.Usuarios_Direcciones();
        public Models.Usuarios_Direcciones Usuarios_Direcciones_Seleccionar(string Clave)
        {
            return _usuarios_Direcciones.Usuarios_Direcciones_Seleccionar(Clave);
        }

        public List<Models.Usuarios_Direcciones> Usuarios_Direcciones_Selecionar_IdUsuario(Models.Usuarios usuarios)
        {
            return _usuarios_Direcciones.Usuarios_Direcciones_Selecionar_IdUsuario(usuarios);
        }

        public Models.Cliente Usuarios_Direcciones_Agregar(string Clave, Models.Usuarios_Direcciones usuarios_Direcciones)
        {
            return _usuarios_Direcciones.Usuarios_Direcciones_Agregar(Clave, usuarios_Direcciones);
        }

        public Models.Usuarios_Direcciones Usuarios_Direcciones_Seleccionar_Id(int Id)
        {
            return _usuarios_Direcciones.Usuarios_Direcciones_Seleccionar_Id(Id);
        }
    }
}
