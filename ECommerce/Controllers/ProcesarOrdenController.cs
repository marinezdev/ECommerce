using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class ProcesarOrdenController : Controller
    {
        Models.Usuarios Usuairo = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
        // GET: ProcesarOrden
        public ActionResult Index(Application.Menu menu, Application.Venta venta)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            Models.Venta CnVenta = new Models.Venta();
            Models.Venta_Consultar venta_Consultar = new Models.Venta_Consultar();
            List<Models.Articulo> articulos = new List<Models.Articulo>();

            Models.Usuarios Usuairo = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

            if (menu.ValidacionPagina(Usuairo, url))
            {
                int IdVenta = 0;
                if (!String.IsNullOrEmpty(Request.QueryString["IdVenta"]))
                {
                    IdVenta = Convert.ToInt32(Request.QueryString["IdVenta"].ToString());
                    CnVenta.Id = IdVenta;
                    venta_Consultar = venta.Venta_Consultar_Id(CnVenta);
                    articulos = venta.Venta_Listar_Articulos(CnVenta);

                    ViewBag.venta_Consultar = venta_Consultar;
                    ViewBag.articulos = articulos;
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Adm", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }

        [HttpPost]
        public JsonResult Procear_Venta(Models.Venta venta, Application.Venta APventa)
        {
            venta.IdUsuario = Usuairo.IdUsuario;
            return Json(APventa.SPProcesarVenta(venta));
        }

    }
}
