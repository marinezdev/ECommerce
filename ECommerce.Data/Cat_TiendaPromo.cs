using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;

namespace ECommerce.Data
{
	public class Cat_TiendaPromo
	{
        ManejoDatos b = new ManejoDatos();

        public List<Models.Cat_TiendaPromo> Cat_TiendaPromo_Listar(int num)
        {
            const string consulta = "Cat_TiendaPromo_Listar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@num", num, SqlDbType.Int);

            List <Models.Cat_TiendaPromo> resultado = new List<Models.Cat_TiendaPromo>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_TiendaPromo>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        //public List<Models.Cat_TiendaPromo> Cat_TiendaPromo_Listar()
        //{
        //    b.ExecuteCommandSP("Cat_TiendaPromo_Listar");
        //    List<Models.Cat_TiendaPromo> resultado = new List<Models.Cat_TiendaPromo>();
        //    var reader = b.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        Models.Cat_TiendaPromo item = new Models.Cat_TiendaPromo()
        //        {
        //            //Id = Convert.ToInt32(reader["Id"]),
        //            Titulo = reader["Titulo"].ToString(),
        //            Subtitulo = reader["Subtitulo"].ToString(),
        //            Descripcion = reader["Descripcion"].ToString(),
        //            URLImg = reader["URLImg"].ToString(),
        //            Link = reader["Link"].ToString(),
        //        };
        //        resultado.Add(item);
        //    }
        //    reader = null;
        //    b.ConnectionCloseToTransaction();
        //    return resultado;
        //}
    }
}

