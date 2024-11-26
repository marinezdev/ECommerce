using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Cat_Subcategoria
    {
        public int Id { get; set; }
        public int IdCatCategoriaProducto { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
    }
}
