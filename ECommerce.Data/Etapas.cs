using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Etapas
    {
        ManejoDatos b = new ManejoDatos();

        public Models.Cat_FlujoBase Etapas_Agregar(Models.Cat_FlujoBase cat_FlujoBase)
        {
            b.ExecuteCommandSP("Etapas_Agregar");
            b.AddParameter("@IdFlujo", cat_FlujoBase.IdFlujo, SqlDbType.Int);
            b.AddParameter("@Nombre", cat_FlujoBase.Nombre, SqlDbType.VarChar);
            b.AddParameter("@Orden", cat_FlujoBase.Etapa, SqlDbType.Int);

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
