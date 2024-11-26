using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class RastreaPedidosController : Controller
    {
        // GET: RastreaPedidos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rastreo(Application.Venta_Folio APVentaFolio, Application.Venta APVenta)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["F"]))
            {
                List<Models.Articulo> dtArticulos = new List<Models.Articulo>();
                Models.Venta_Folio Venta_Folio = new Models.Venta_Folio();
                Models.Venta venta = new Models.Venta();

                Venta_Folio.FolioCompuesto = Request.QueryString["F"].ToString();
                Models.Consultas.VentaFolio dtVenta = APVentaFolio.Venta_Folio_Busqueda(Venta_Folio);

                if (dtVenta.Venta.Id > 0)
                {
                    venta.Id = dtVenta.Venta.Id;
                    dtArticulos = APVenta.Venta_Listar_Articulos(venta);
                }

                ViewBag.Venta = dtVenta;
                ViewBag.Articulos = dtArticulos;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "RastreaPedido");
            }
        }
    }
}
