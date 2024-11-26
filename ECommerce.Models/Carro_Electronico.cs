using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Carro_Electronico
    {
        public int IdArticulo { get; set; }
        public int Item { get; set; }
        public int Total { get; set; }

        public string TotalText { get; set; }
        public string Nombre { get; set; }
        public string Clasificacion { get; set; }
        public string Precio { get; set; }
        public string PrecioText { get; set; }
        public string Imagen { get; set; }
        public int Id { get; set; }

        public string TotalArticulo { get; set; }
        public string TotalNota { get; set; }

    }
}
