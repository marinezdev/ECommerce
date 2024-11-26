using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class AdministracionController : Controller
    {
        // GET: Administracion
        public ActionResult Index(Application.Menu menu)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

            Models.Usuarios Usuairo = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

            if (menu.ValidacionPagina(Usuairo, url))
            {
                
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Adm", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }
    }
}
