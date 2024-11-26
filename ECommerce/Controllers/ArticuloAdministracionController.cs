using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class ArticuloAdministracionController : Controller
    {
        // GET: ArticuloAdministracion
        public ActionResult Index(Application.Menu menu, Application.Articulo articulo)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

            Models.Usuarios Usuairo = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

            if (menu.ValidacionPagina(Usuairo, url))
            {
                ViewBag.Artiuclos = articulo.Articulo_Listar();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Adm", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }
    }
}
