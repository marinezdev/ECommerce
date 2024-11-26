using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Mensaje
    {
        public string Contenido { get; set; }
        public bool Respuesta { get; set; }
        public string RespuestaText { get; set; }
        public string Token { get; set; }
    }
}
