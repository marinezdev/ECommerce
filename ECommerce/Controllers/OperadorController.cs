using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class OperadorController : Controller
    {
        // GET: Operador
        public ActionResult Index(Application.Menu menu, Application.Venta venta)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

            Models.Usuarios Usuairo = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

            if (menu.ValidacionPagina(Usuairo, url))
            {
                List<Models.Venta> Venta_Listar_Pendietes_Etapa_Total = venta.Venta_Listar_Pendietes_Etapa_Total(Usuairo);
                ViewBag.Venta_Listar_Pendietes_Etapa_Total = Venta_Listar_Pendietes_Etapa_Total;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Adm", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }

        }

        public ActionResult Ordenes(Application.Menu menu, Application.Venta venta)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

            Models.Usuarios Usuairo = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

            if (menu.ValidacionPagina(Usuairo, url))
            {
                List<Models.Venta> Venta_Listar_Pendientes = venta.Venta_Listar_Pendientes(Usuairo);
                List<Models.Venta> Venta_Listar_Operador = venta.Venta_Listar_Operador();
                List<Models.Venta> Venta_Listar_Pendietes_Etapa_Total = venta.Venta_Listar_Pendietes_Etapa_Total(Usuairo);

                ViewBag.Venta_Listar_Pendientes = Venta_Listar_Pendientes;
                ViewBag.Venta_Listar_Operador = Venta_Listar_Operador;
                ViewBag.Venta_Listar_Pendietes_Etapa_Total = Venta_Listar_Pendietes_Etapa_Total;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Adm", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }

        }

        public ActionResult MostrarOrden(Application.Menu menu, Application.Venta venta)
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
        public JsonResult ConsultarArticulos(Models.Venta venta, Application.Venta APventa)
        {
            List<Models.Articulo>  articulos = APventa.Venta_Listar_Articulos(venta);
            return Json(articulos);
        }



    }
}
