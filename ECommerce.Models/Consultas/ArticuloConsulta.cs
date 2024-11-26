using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.Consultas
{
    public class ArticuloConsulta
    {
        public Articulo Articulo { get; set; }
        public Cat_Subcategoria Cat_Subcategoria { get; set; }
        public Cat_Clasificacion Cat_Clasificacion { get; set; }
        public Cat_CategoriaProducto Cat_CategoriaProducto { get; set; }
    }
}
