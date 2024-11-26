using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Cookie_Carrito
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Cookie_Carrito Cookie_Carrito_Registrar()
        {
            b.ExecuteCommandSP("Cookie_Carrito_Registrar");
            Models.Cookie_Carrito resultado = new Models.Cookie_Carrito();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Clave = reader["Clave"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
