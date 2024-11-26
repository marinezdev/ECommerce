using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Articulo
    {
        Data.Articulo _Articulo = new Data.Articulo();
        public Models.Articulo Articulo_registrar(Models.Articulo articulo)
        {
            return _Articulo.Articulo_registrar(articulo);
        }

        public List<Models.Articulo> Articulo_Listar()
        {
            return _Articulo.Articulo_Listar();
        }

        public List<Models.Articulo> Articulos_Store_Listar()
        {
            return _Articulo.Articulos_Store_Listar();
        }

        public Models.Consultas.ArticuloConsulta Articulo_Selecionar_IdArticulo(Models.Articulo articulo) 
        {
            Models.Consultas.ArticuloConsulta articuloConsulta = _Articulo.Articulo_Selecionar_IdArticulo(articulo);

            decimal Precio = 0;
            Precio += Convert.ToDecimal(articuloConsulta.Articulo.PrecioPublico);
            string Total = string.Format("{0:N2}", Precio); 
            articuloConsulta.Articulo.PrecioPublico = Total;

            return articuloConsulta;
        }
    }
}
