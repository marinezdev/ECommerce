using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class AtributosController : Controller
    {
        // GET: Atributos
        public ActionResult Index(Application.Menu menu, Application.Cat_CategoriaProducto cat_CategoriaProducto, Application.Cat_TipoDatos cat_TipoDatos)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

            Models.Usuarios Usuairo = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

            if (menu.ValidacionPagina(Usuairo, url))
            {

                ViewBag.cat_CategoriaProducto = cat_CategoriaProducto.Cat_CategoriaProducto_Listar();
                ViewBag.cat_TipoDatos = cat_TipoDatos.Cat_FlujoBase_Listar();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Adm", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }

        [HttpPost]
        public JsonResult Atributo_Buscar(Models.Cat_Atributos cat_Atributos, Application.Cat_Atributos _cat_Atributos1)
        {
            List<Models.Cat_Atributos> ResulAtributos = _cat_Atributos1.Cat_Atributos_Listar(cat_Atributos);
            return Json(ResulAtributos);
        }

        [HttpPost]
        public JsonResult Atributo_Agregar(Models.Cat_Atributos cat_Atributos, Application.Cat_Atributos _cat_Atributos1)
        {
            Models.Cat_Atributos ResulAtributos = _cat_Atributos1.Atributo_Agregar(cat_Atributos);
            return Json(ResulAtributos);
        }


        [HttpPost]
        public JsonResult Atributo_Eliminar(Models.Cat_Atributos cat_Atributos, Application.Cat_Atributos _cat_Atributos1)
        {
            Models.Cat_Atributos ResulAtributos = _cat_Atributos1.Atributo_Eliminar(cat_Atributos);
            return Json(ResulAtributos);
        }


        [HttpPost]
        public JsonResult Atributo_Buscar_Id(Models.Cat_Atributos cat_Atributos, Application.Cat_Atributos _cat_Atributos1)
        {
            Models.Cat_Atributos ResulAtributos = _cat_Atributos1.Atributo_Buscar_Id(cat_Atributos);
            return Json(ResulAtributos);
        }

        [HttpPost]
        public JsonResult Atributo_Editar(Models.Cat_Atributos cat_Atributos, Application.Cat_Atributos _cat_Atributos1)
        {
            Models.Cat_Atributos ResulAtributos = _cat_Atributos1.Atributo_Editar(cat_Atributos);
            return Json(ResulAtributos);
        }
        
    }
}
