using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Menu
    {
        ManejoDatos b = new ManejoDatos();

        public Models.Mensaje ValidaPaginas(Models.Usuarios usuario, string url)
        {
            b.ExecuteCommandSP("Menu_Selecionar_rol");
            b.AddParameter("@IdRol", usuario.IdRol, SqlDbType.Int);
            b.AddParameter("@url", url, SqlDbType.VarChar);

            Models.Mensaje resultado = new Models.Mensaje();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Respuesta = Convert.ToBoolean(Convert.ToInt32(reader["Respuesta"].ToString()));
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
