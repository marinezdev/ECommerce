using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class EtapasUsuario
    {
        public int Id { get; set; }
        public int IdEtapa { get; set; }
        public int IdUsuario { get; set; } 
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
    }
}
