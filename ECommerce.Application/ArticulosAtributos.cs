using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class ArticulosAtributos
    {
        Data.ArticulosAtributos _ArticulosAtributos = new Data.ArticulosAtributos();
        public List<Models.Consultas.ArticuloAtributos> Articulo_Atributos_Selecionar(Models.Articulo articulo)
        {
            return _ArticulosAtributos.Articulo_Atributos_Selecionar(articulo);
        }
    }
}
