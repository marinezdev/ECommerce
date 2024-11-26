using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class CategoriaController : Controller
    {
        Models.Usuarios Usuairo = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
        // GET: Categoria
        public ActionResult Index(Application.Menu menu, Application.Cat_CategoriaProducto cat_CategoriaProducto)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

            List<Models.Cat_CategoriaProducto> dtCategorias = cat_CategoriaProducto.Cat_CategoriaProducto_Listar();

            if (menu.ValidacionPagina(Usuairo, url))
            {
                ViewBag.Categorias = dtCategorias;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Adm", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }

        [HttpPost]
        public JsonResult Categoria_Actualizar(Models.Cat_CategoriaProducto cat_CategoriaProducto, Application.Cat_CategoriaProducto cat_CategoriaProducto1)
        {
            cat_CategoriaProducto.IdUsuario = Usuairo.IdUsuario;
            Models.Cat_CategoriaProducto cat_Categoria = cat_CategoriaProducto1.Cat_CategoriaProducto_Agregar(cat_CategoriaProducto);
            return Json(cat_Categoria);
        }

        [HttpPost]
        public JsonResult Categoria_Agregar(Models.Cat_CategoriaProducto cat_CategoriaProducto, Application.Cat_CategoriaProducto cat_CategoriaProducto1)
        {
            cat_CategoriaProducto.Id = Usuairo.IdUsuario;
            Models.Cat_CategoriaProducto cat_Categoria = cat_CategoriaProducto1.Cat_CategoriaProducto_Agregar(cat_CategoriaProducto);
            return Json(cat_Categoria);
        }

        [HttpPost]
        public JsonResult Categoria_Listar( Application.Cat_CategoriaProducto cat_CategoriaProducto1)
        {
            List<Models.Cat_CategoriaProducto> cat_Categoria = cat_CategoriaProducto1.Cat_CategoriaProducto_Listar();
            return Json(cat_Categoria);
        }

        [HttpPost]
        public JsonResult Subcategoria_Agregar(Models.Cat_Subcategoria cat_Subcategoria, Application.Cat_Subcategoria cat_Subcategoria1)
        {
            List<Models.ArticuloImg> LstArticuloImg = new List<Models.ArticuloImg>();

            if (Session["ImageneSubCategoria"] != null)
            {
                LstArticuloImg = (List<Models.ArticuloImg>)Session["ImageneSubCategoria"];
            }

            cat_Subcategoria.Id = Usuairo.IdUsuario;
            cat_Subcategoria.Imagen = LstArticuloImg[0].ImagenURL;
            Models.Cat_Subcategoria cat_Categoria = cat_Subcategoria1.Cat_Subcategoria_Agregar(cat_Subcategoria);

            if (cat_Categoria.Id > 0)
            {
                Session["ImageneSubCategoria"] = null;
            }
            return Json(cat_Categoria);
        }

        [HttpPost]
        public JsonResult SubCategoria_Listar(Models.Cat_CategoriaProducto cat_CategoriaProducto,Application.Cat_Subcategoria cat_Subcategoria)
        {
            List<Models.Cat_Subcategoria> cat_Subcategorias = cat_Subcategoria.Cat_Subcategoria_Listar(cat_CategoriaProducto);
            return Json(cat_Subcategorias);
        }

        [HttpPost]
        public JsonResult Clasificacion_Agregar(Models.Cat_Clasificacion cat_Clasificacion, Application.Cat_Clasificacion cat_Clasificacion1)
        {
            List<Models.ArticuloImg> LstArticuloImg = new List<Models.ArticuloImg>();

            if (Session["ImageneClasificacion"] != null)
            {
                LstArticuloImg = (List<Models.ArticuloImg>)Session["ImageneClasificacion"];
            }

            cat_Clasificacion.Id = Usuairo.IdUsuario;
            cat_Clasificacion.Imagen = LstArticuloImg[0].ImagenURL;
            Models.Cat_Clasificacion cat_Clasificacion2 = cat_Clasificacion1.Cat_Clasificacion_Agregar(cat_Clasificacion);
            
            if(cat_Clasificacion2.Id > 0)
            {
                Session["ImageneClasificacion"] = null;
            }

            return Json(cat_Clasificacion2);
        }

        [HttpPost]
        public JsonResult Clasificacion_Listar(Models.Cat_Clasificacion cat_Clasificacion , Application.Cat_Clasificacion cat_Clasificacion1)
        {
            List<Models.Cat_Clasificacion> cat_Clasificacions = cat_Clasificacion1.Cat_Clasificacion_Listar(cat_Clasificacion);
            return Json(cat_Clasificacions);
        }
        
        [HttpPost]
        public JsonResult CargaImagenes(List<Models.ArticuloImg> ListaImagenes)
        {
            List<Models.ArticuloImg> LstArticuloImg = new List<Models.ArticuloImg>();

            Session["ImageneSubCategoria"] = null;

            foreach (var dt in ListaImagenes)
            {
                LstArticuloImg.Add(dt);
            }

            Session["ImageneSubCategoria"] = LstArticuloImg;

            return Json(LstArticuloImg);
        }

        [HttpPost]
        public JsonResult ConsulltaImagenes()
        {
            List<Models.ArticuloImg> LstArticuloImg = new List<Models.ArticuloImg>();

            if (Session["ImageneSubCategoria"] != null)
            {
                LstArticuloImg = (List<Models.ArticuloImg>)Session["ImageneSubCategoria"];
            }

            return Json(LstArticuloImg);
        }

        [HttpPost]
        public JsonResult CargaImagenesClasificacion(List<Models.ArticuloImg> ListaImagenes)
        {
            List<Models.ArticuloImg> LstArticuloImg = new List<Models.ArticuloImg>();

            Session["ImageneClasificacion"] = null;

            foreach (var dt in ListaImagenes)
            {
                LstArticuloImg.Add(dt);
            }

            Session["ImageneClasificacion"] = LstArticuloImg;

            return Json(LstArticuloImg);
        }

        [HttpPost]
        public JsonResult ConsulltaImagenesClasificacion()
        {
            List<Models.ArticuloImg> LstArticuloImg = new List<Models.ArticuloImg>();

            if (Session["ImageneClasificacion"] != null)
            {
                LstArticuloImg = (List<Models.ArticuloImg>)Session["ImageneClasificacion"];
            }

            return Json(LstArticuloImg);
        }
    }
}
