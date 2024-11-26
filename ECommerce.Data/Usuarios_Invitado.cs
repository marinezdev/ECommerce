using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Usuarios_Invitado
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Cliente Usuarios_Invitado_Agregar(string Clave,Models.Usuarios_Invitado usuarios_Invitado)
        {
            b.ExecuteCommandSP("Usuarios_Invitado_Agregar");
            b.AddParameter("@Clave", Clave, SqlDbType.VarChar);
            b.AddParameter("@Nombre", usuarios_Invitado.Nombre, SqlDbType.VarChar);
            b.AddParameter("@ApellidoPaterno", usuarios_Invitado.ApellidoPaterno, SqlDbType.VarChar);
            b.AddParameter("@ApellidoMaterno", usuarios_Invitado.ApellidoMaterno, SqlDbType.VarChar);
            b.AddParameter("@Correo", usuarios_Invitado.Correo, SqlDbType.VarChar);
            b.AddParameter("@Telefono", usuarios_Invitado.Telefono, SqlDbType.VarChar);
            b.AddParameter("@TipoTelefono", usuarios_Invitado.TipoTelefono, SqlDbType.VarChar);
            b.AddParameter("@Publicidad", usuarios_Invitado.Publicidad, SqlDbType.Int);

            b.AddParameter("@IdEstado", usuarios_Invitado.IdEstado, SqlDbType.Int);
            b.AddParameter("@IdPoblacion", usuarios_Invitado.IdPoblacion, SqlDbType.Int);
            b.AddParameter("@IdColonia", usuarios_Invitado.IdColonia, SqlDbType.Int);
            b.AddParameter("@CP", usuarios_Invitado.CP, SqlDbType.VarChar);
            b.AddParameter("@NumExterior", usuarios_Invitado.NumExterior, SqlDbType.VarChar);
            b.AddParameter("@NumInteriror", usuarios_Invitado.NumInteriror, SqlDbType.VarChar);
            b.AddParameter("@Calle", usuarios_Invitado.Calle, SqlDbType.VarChar);
            b.AddParameter("@EntreCalles", usuarios_Invitado.EntreCalles, SqlDbType.VarChar);
            b.AddParameter("@Referencias", usuarios_Invitado.Referencias, SqlDbType.VarChar);

            b.AddParameter("@RecibirPedido", usuarios_Invitado.RecibirPedido, SqlDbType.Int);
            b.AddParameter("@Recibe_Nombre", usuarios_Invitado.Recibe_Nombre, SqlDbType.VarChar);
            b.AddParameter("@Recibe_Apellidos", usuarios_Invitado.Recibe_Apellidos, SqlDbType.VarChar);
            b.AddParameter("@Recibe_Telefono", usuarios_Invitado.Recibe_Telefono, SqlDbType.VarChar);
            b.AddParameter("@Recibe_TipoTelefono", usuarios_Invitado.Recibe_TipoTelefono, SqlDbType.VarChar);

            Models.Cliente resultado = new Models.Cliente();
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
