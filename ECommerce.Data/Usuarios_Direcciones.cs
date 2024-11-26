using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Usuarios_Direcciones
    {
        ManejoDatos b = new ManejoDatos();

        public Models.Usuarios_Direcciones Usuarios_Direcciones_Seleccionar(string Clave)
        {
            b.ExecuteCommandSP("Usuarios_Direcciones_Seleccionar");
            b.AddParameter("@Clave", Clave, SqlDbType.NVarChar);
            Models.Usuarios_Direcciones resultado = new Models.Usuarios_Direcciones();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                resultado.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                resultado.Correo = reader["Correo"].ToString();
                resultado.Telefono = reader["Telefono"].ToString();
                resultado.TipoTelefono = reader["TipoTelefono"].ToString();

                resultado.IdDireccion = Convert.ToInt32(reader["IdDireccion"].ToString());
                resultado.Estado = reader["Estado"].ToString();
                resultado.Poblacion = reader["Poblacion"].ToString();
                resultado.Colonia = reader["Colonia"].ToString();
                resultado.CP = reader["CP"].ToString();

                resultado.Calle = reader["Calle"].ToString();
                resultado.NumExterior = reader["NumExterior"].ToString();
                resultado.NumInteriror = reader["NumInteriror"].ToString();
                resultado.EntreCalles = reader["EntreCalles"].ToString();
                resultado.Referencias = reader["Referencias"].ToString();

                resultado.RecibirPedido = Convert.ToInt32(reader["RecibirPedido"].ToString());
                resultado.Recibe_Nombre = reader["Recibe_Nombre"].ToString();
                resultado.Recibe_Apellidos = reader["Recibe_Apellidos"].ToString();
                resultado.Recibe_Telefono = reader["Recibe_Telefono"].ToString();
                resultado.Recibe_TipoTelefono = reader["Recibe_TipoTelefono"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Usuarios_Direcciones> Usuarios_Direcciones_Selecionar_IdUsuario(Models.Usuarios usuarios)
        {
            b.ExecuteCommandSP("Usuarios_Direcciones_Selecionar_IdUsuario");
            b.AddParameter("@IdUsuario", usuarios.IdUsuario, SqlDbType.Int);
            List<Models.Usuarios_Direcciones> resultado = new List<Models.Usuarios_Direcciones>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Usuarios_Direcciones item = new Models.Usuarios_Direcciones()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre_Direccion = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.Cliente Usuarios_Direcciones_Agregar(string Clave, Models.Usuarios_Direcciones usuarios_Direcciones)
        {
            b.ExecuteCommandSP("Usuarios_Direcciones_Agregar");
            b.AddParameter("@Clave", Clave, SqlDbType.VarChar);
            b.AddParameter("@IdUsuario", usuarios_Direcciones.IdUsuario, SqlDbType.Int);
            b.AddParameter("@Telefono", usuarios_Direcciones.Telefono, SqlDbType.NVarChar);
            b.AddParameter("@TipoTelefono", usuarios_Direcciones.TipoTelefono, SqlDbType.NVarChar);
            b.AddParameter("@Publicidad", usuarios_Direcciones.Publicidad, SqlDbType.Int);

            b.AddParameter("@IdEstado", usuarios_Direcciones.IdEstado, SqlDbType.Int);
            b.AddParameter("@IdPoblacion", usuarios_Direcciones.IdPoblacion, SqlDbType.Int);
            b.AddParameter("@IdColonia", usuarios_Direcciones.IdColonia, SqlDbType.Int);
            b.AddParameter("@CP", usuarios_Direcciones.CP, SqlDbType.NVarChar);
            b.AddParameter("@NumExterior", usuarios_Direcciones.NumExterior, SqlDbType.NVarChar);
            b.AddParameter("@NumInteriror", usuarios_Direcciones.NumInteriror, SqlDbType.NVarChar);
            b.AddParameter("@Calle", usuarios_Direcciones.Calle, SqlDbType.NVarChar);
            b.AddParameter("@EntreCalles", usuarios_Direcciones.EntreCalles, SqlDbType.NVarChar);
            b.AddParameter("@Referencias", usuarios_Direcciones.Referencias, SqlDbType.NVarChar);

            b.AddParameter("@RecibirPedido", usuarios_Direcciones.RecibirPedido, SqlDbType.Int);
            b.AddParameter("@Recibe_Nombre", usuarios_Direcciones.Recibe_Nombre, SqlDbType.NVarChar);
            b.AddParameter("@Recibe_Apellidos", usuarios_Direcciones.Recibe_Apellidos, SqlDbType.NVarChar);
            b.AddParameter("@Recibe_Telefono", usuarios_Direcciones.Recibe_Telefono, SqlDbType.NVarChar);
            b.AddParameter("@Recibe_TipoTelefono", usuarios_Direcciones.Recibe_TipoTelefono, SqlDbType.NVarChar);

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

        public Models.Usuarios_Direcciones Usuarios_Direcciones_Seleccionar_Id(int Id)
        {
            b.ExecuteCommandSP("Usuarios_Direcciones_Seleccionar_Id");
            b.AddParameter("@Id", Id, SqlDbType.Int);
            Models.Usuarios_Direcciones resultado = new Models.Usuarios_Direcciones();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
                resultado.Nombre_Direccion = reader["Nombre"].ToString();
                resultado.IdDireccion = Convert.ToInt32(reader["Id"].ToString());
                resultado.Estado = reader["Estado"].ToString();
                resultado.Poblacion = reader["Poblacion"].ToString();
                resultado.Colonia = reader["Colonia"].ToString();
                resultado.CP = reader["CP"].ToString();

                resultado.Calle = reader["Calle"].ToString();
                resultado.NumExterior = reader["NumExterior"].ToString();
                resultado.NumInteriror = reader["NumInteriror"].ToString();
                resultado.EntreCalles = reader["EntreCalles"].ToString();
                resultado.Referencias = reader["Referencias"].ToString();

                resultado.RecibirPedido = Convert.ToInt32(reader["RecibirPedido"].ToString());
                resultado.Recibe_Nombre = reader["Recibe_Nombre"].ToString();
                resultado.Recibe_Apellidos = reader["Recibe_Apellidos"].ToString();
                resultado.Recibe_Telefono = reader["Recibe_Telefono"].ToString();
                resultado.Recibe_TipoTelefono = reader["Recibe_TipoTelefono"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    }
}
