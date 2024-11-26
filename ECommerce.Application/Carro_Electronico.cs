using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Carro_Electronico
    {
        Data.Carro_Electronico _carro_Electronico = new Data.Carro_Electronico();
        public Models.Mensaje Carro_Electronico_Registrar_Articulo(string Clave, Models.Carro_Electronico carro_Electronico)
        {
            return _carro_Electronico.Carro_Electronico_Registrar_Articulo(Clave, carro_Electronico);
        }
        public Models.Carro_Electronico Carro_Electronico_Consultar_Total(string Clave)
        {
            Models.Carro_Electronico InteresV = _carro_Electronico.Carro_Electronico_Consultar_Total(Clave);
            return InteresV;
        }
        public List<Models.Carro_Electronico> Carro_Electronico_Listar_Articulos(string Clave)
        {
            List<Models.Carro_Electronico> ListaCarrito_Electronico = _carro_Electronico.Carro_Electronico_Listar_Articulos(Clave);
            return ListaCarrito_Electronico;
        }
        public Models.Mensaje Carrito_Eliminar_Articulo(string Clave, Models.Carro_Electronico carro_Electronico)
        {
            return _carro_Electronico.Carrito_Eliminar_Articulo(Clave, carro_Electronico);
        }
        public Models.Carro_Electronico Carrito_Actualizar(string Clave, Models.Carro_Electronico carro_Electronico)
        { 
            Models.Carro_Electronico carrito = _carro_Electronico.Carrito_Actualizar(Clave, carro_Electronico);
            return carrito;
        }

    }
}
