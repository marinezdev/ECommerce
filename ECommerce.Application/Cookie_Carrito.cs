using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class  Cookie_Carrito
    {
        Data.Cookie_Carrito _Cookie_Carrito = new Data.Cookie_Carrito();
        public Models.Cookie_Carrito Cookie_Carrito_Registrar()
        {
            return _Cookie_Carrito.Cookie_Carrito_Registrar();
        }
    }
}
