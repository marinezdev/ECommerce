using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Articulo
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public int IdSubCategoria { get; set; }
        public int IdClasificacion { get; set; }
        public int IdFlujo { get; set; }
        public string Nombre { get; set; }
        public string SKU { get; set; }
        public int Stock { get; set; }
        public string Descripcion { get; set; }
        public string Largo { get; set; }
        public string Ancho { get; set; }
        public string Altura { get; set; }
        public string Peso { get; set; }
        public int Envio { get; set; }
        public string PrecioPublico { get; set; }
        public string PrecioDistribuidor { get; set; }
        public int IdMoneda { get; set; }
        public int Promocion { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public decimal Precio { get; set; }
        public int IdMonedaPromocion { get; set; }
        public string Informacion { get; set; }
        public string PrecioText { get; set; }
        public string Imagen { get; set; }
        public string Clasificacion { get; set; }
        public string Moneda { get; set; }
    }
}
