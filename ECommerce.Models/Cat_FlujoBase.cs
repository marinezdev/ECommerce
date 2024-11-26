using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Cat_FlujoBase
    {
        public int Id { get; set; }
        public int IdFlujo { get; set; }
        public string Nombre { get; set; }
        public int Etapa { get; set; }
        public int Orden { get; set; }

        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
    }
}
