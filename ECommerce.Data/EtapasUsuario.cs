using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class EtapasUsuario
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.EtapasUsuario> Usuarios_listar_Asignacion(Models.EtapasUsuario etapasUsuario)
        {
            b.ExecuteCommandSP("Usuarios_listar_Asignacion");
            List<Models.EtapasUsuario> resultado = new List<Models.EtapasUsuario>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.EtapasUsuario item = new Models.EtapasUsuario()
                {
                    NombreUsuario = reader["Nombre"].ToString(),
                    Correo = reader["Correo"].ToString(),
                    IdEtapa = Convert.ToInt32(etapasUsuario.IdEtapa),
                    Id = Convert.ToInt32(reader["Id"]),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Cat_FlujoBase EtapasUsuarios_Agregar(Models.Cat_FlujoBase cat_FlujoBase)
        {
            b.ExecuteCommandSP("EtapasUsuarios_Agregar");
            b.AddParameter("@IdEtapa", cat_FlujoBase.Etapa, SqlDbType.Int);
            b.AddParameter("@IdUsuario", cat_FlujoBase.IdUsuario, SqlDbType.VarChar);

            Models.Cat_FlujoBase resultado = new Models.Cat_FlujoBase();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
