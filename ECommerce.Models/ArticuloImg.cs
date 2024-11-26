using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class ArticuloImg
    {
        public int Id { get; set; }
        public int IdArticulo { get; set; }
        public int IdArchivo { get; set; }
        public string NmArchivo { get; set; }
        public string NmOriginal { get; set; }
        public string ImagenURL { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public int Activo { get; set; }
        public int Rechazos { get; set; }
    }
}
