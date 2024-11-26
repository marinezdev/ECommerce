using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Usuario
    {
        ManejoDatos b = new ManejoDatos();

        public Models.Usuarios Usuario_Selecionar_Pas_US(Models.Usuarios usuarios)
        {
            b.ExecuteCommandSP("Usuario_Selecionar_Pas_US");
            b.AddParameter("@Email", usuarios.Email, SqlDbType.VarChar);
            b.AddParameter("@Password", usuarios.Password, SqlDbType.VarChar);
            b.AddParameter("@Session", usuarios.Session, SqlDbType.Bit);

            Models.Usuarios resultado = new Models.Usuarios();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.IdUsuario = Convert.ToInt32(reader["Id"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.Apellidos = reader["Apellidos"].ToString();
                resultado.Email = reader["Correo"].ToString();
                resultado.Telefono = reader["Telefono"].ToString();
                resultado.TipoTelefono = reader["TipoTelefono"].ToString();
                resultado.IdRol = Convert.ToInt32(reader["IdRol"].ToString());
                resultado.NombreRol = reader["NombreRol"].ToString();
                resultado.RutaAcceso = reader["RutaAcceso"].ToString();
                resultado.Mensaje = reader["Mensaje"].ToString();
                resultado.ClaveCoo = reader["ClaveCoo"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Usuarios coo_Session_Seleccionar(string Clave)
        {
            b.ExecuteCommandSP("coo_Session_Seleccionar");
            b.AddParameter("@Clave", Clave, SqlDbType.VarChar);

            Models.Usuarios resultado = new Models.Usuarios();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.IdUsuario = Convert.ToInt32(reader["Id"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.Apellidos = reader["Apellidos"].ToString();
                resultado.Email = reader["Correo"].ToString();
                resultado.IdRol = Convert.ToInt32(reader["IdRol"].ToString());
                resultado.NombreRol = reader["NombreRol"].ToString();
                resultado.RutaAcceso = reader["RutaAcceso"].ToString();
                resultado.Mensaje = reader["Mensaje"].ToString();
                resultado.ClaveCoo = reader["ClaveCoo"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Usuarios Consulta_Usuario_Nombre(int IdUsuario)
        {
            b.ExecuteCommandSP("Usuario_Selecionar_Nombre");
            b.AddParameter("@IdUsuario", IdUsuario, SqlDbType.Int);

            Models.Usuarios resultado = new Models.Usuarios();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Nombre = reader["Nombre"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        

    }
}
