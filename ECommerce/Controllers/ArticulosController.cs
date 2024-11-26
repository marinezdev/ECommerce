using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class ArticulosController : Controller
    {
        // GET: Articulos
        public ActionResult NuevoArticulo(Application.Menu menu, Application.Flujo flujo, Application.Cat_CategoriaProducto cat_CategoriaProducto, Application.Cat_TipoDatos cat_TipoDatos, Application.Cat_Moneda cat_Moneda)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

            Models.Usuarios Usuairo = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

            if (menu.ValidacionPagina(Usuairo, url))
            {

                ViewBag.cat_CategoriaProducto = cat_CategoriaProducto.Cat_CategoriaProducto_Listar();
                ViewBag.flujo = flujo.Flujo_Listar();
                ViewBag.cat_TipoDatos = cat_TipoDatos.Cat_FlujoBase_Listar();
                ViewBag.cat_Moneda = cat_Moneda.Cat_Moneda_Listar();

                Session["Imagenes"] = null;
                Session["AtributosArticulo"] = null;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Adm", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }

        [HttpPost]
        public JsonResult CargaImagenes(List<Models.ArticuloImg> ListaImagenes)
        {
            List<Models.ArticuloImg> LstInmuebleImg = new List<Models.ArticuloImg>();

            if (Session["Imagenes"] != null)
            {
                LstInmuebleImg = (List<Models.ArticuloImg>)Session["Imagenes"];
            }

            foreach (var dt in ListaImagenes)
            {
                LstInmuebleImg.Add(dt);
            }

            Session["Imagenes"] = LstInmuebleImg;

            return Json(LstInmuebleImg);
        }
        [HttpPost]
        public JsonResult EliminarImagen(Models.ArticuloImg articuloImg)
        {
            string DirectorioUsuario = Server.MapPath("~") + "\\Articulos\\";
            List<Models.ArticuloImg> LstInmuebleImg = new List<Models.ArticuloImg>();
            if (Session["Imagenes"] != null)
            {
                LstInmuebleImg = (List<Models.ArticuloImg>)Session["Imagenes"];
            }

            for (int i = 0; i < LstInmuebleImg.Count; i++)
            {
                if (LstInmuebleImg[i].IdArchivo == articuloImg.IdArchivo)
                {
                    //string extencion = LstInmuebleImg[i].NmArchivo.Split('.')[1];

                    System.IO.File.Delete(DirectorioUsuario + LstInmuebleImg[i].NmArchivo);
                    LstInmuebleImg.Remove(LstInmuebleImg[i]);
                }
            }

            Session["Imagenes"] = LstInmuebleImg;
            return Json(LstInmuebleImg);
        }
        [HttpPost]
        public JsonResult RotarImagen(Models.ArticuloImg articuloImg, Application.Control_Archivos control_Archivos)
        {
            string DirectorioUsuario = Server.MapPath("~") + "Articulos\\";
            string DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\Articulos\\";

            List<Models.ArticuloImg> LstInmuebleImg = new List<Models.ArticuloImg>();
            Models.ArticuloImg InmuebleImg = new Models.ArticuloImg();

            if (Session["Imagenes"] != null)
            {
                LstInmuebleImg = (List<Models.ArticuloImg>)Session["Imagenes"];
            }

            for (int i = 0; i < LstInmuebleImg.Count; i++)
            {
                if (LstInmuebleImg[i].IdArchivo == articuloImg.IdArchivo)
                {
                    InmuebleImg = control_Archivos.RotarImagen(DirectorioUsuario, LstInmuebleImg[i].NmArchivo, DirectorioURL);
                }
            }

            LstInmuebleImg.Add(InmuebleImg);

            return Json(LstInmuebleImg);
        }
        [HttpPost]
        public JsonResult ReacomodarImagen(Models.ArticuloImg articuloImg)
        {
            string DirectorioUsuario = Server.MapPath("~") + "\\Inmuebles\\";
            List<Models.ArticuloImg> LstInmuebleImg = new List<Models.ArticuloImg>();
            List<Models.ArticuloImg> LstInmuebleImgNuevo = new List<Models.ArticuloImg>();

            Models.ArticuloImg UltimaImg = new Models.ArticuloImg();
            if (Session["Imagenes"] != null)
            {
                LstInmuebleImg = (List<Models.ArticuloImg>)Session["Imagenes"];
            }

            UltimaImg = LstInmuebleImg[LstInmuebleImg.Count - 1];

            // elimina el ultimo elemento de la lista
            LstInmuebleImg.Remove(LstInmuebleImg[LstInmuebleImg.Count - 1]);

            // OPTINE LA POCIOCION DEL ELEMENTO A SUSTITUIR 
            int num = 0;
            for (int i = 0; i < LstInmuebleImg.Count; i++)
            {
                if (LstInmuebleImg[i].IdArchivo == articuloImg.IdArchivo)
                {
                    num = i;
                    break;
                    //LstInmuebleImg.Remove(LstInmuebleImg[i]);
                }
            }

            // LLEGA EL LSITADO
            for (int i = 0; i < LstInmuebleImg.Count; i++)
            {
                if (i == num)
                {
                    LstInmuebleImgNuevo.Add(UltimaImg);
                }
                else
                {
                    LstInmuebleImgNuevo.Add(LstInmuebleImg[i]);
                }
            }

            Session["Imagenes"] = LstInmuebleImgNuevo;
            return Json(LstInmuebleImgNuevo);

        }
        [HttpPost]
        public JsonResult OrdenarImagenes(Models.ArticuloImg articuloImg)
        {
            List<Models.ArticuloImg> LstInmuebleImg = new List<Models.ArticuloImg>();
            List<Models.ArticuloImg> LstInmuebleImgNuevo = new List<Models.ArticuloImg>();

            if (Session["Imagenes"] != null)
            {
                LstInmuebleImg = (List<Models.ArticuloImg>)Session["Imagenes"];
            }

            // TOMA LA IMAGEN ESCOGIDA
            for (int i = 0; i < LstInmuebleImg.Count; i++)
            {
                if (LstInmuebleImg[i].IdArchivo == articuloImg.IdArchivo)
                {
                    LstInmuebleImgNuevo.Add(LstInmuebleImg[i]);
                }
            }

            // LLEGA EL LSITADO
            for (int i = 0; i < LstInmuebleImg.Count; i++)
            {
                if (LstInmuebleImg[i].IdArchivo != articuloImg.IdArchivo)
                {
                    LstInmuebleImgNuevo.Add(LstInmuebleImg[i]);
                }
            }
            Session["Imagenes"] = LstInmuebleImgNuevo;
            return Json(LstInmuebleImgNuevo);
        }

        [HttpPost]
        public JsonResult AtributoArticulo_ConsultaId(Models.Cat_Atributos cat_Atributos)
        {
            bool result = false;
            List<Models.Cat_Atributos> LstCat_Atributos = new List<Models.Cat_Atributos>();
            if (Session["AtributosArticulo"] != null)
            {
                LstCat_Atributos = (List<Models.Cat_Atributos>)Session["AtributosArticulo"];
            }

            foreach (var dt in LstCat_Atributos)
            {
                if (cat_Atributos.Id == dt.Id)
                {
                    result = true;
                    break;
                }
            }

            return Json(result);
        }
        [HttpPost]
        public JsonResult AtributoArticulo_Agregar(Models.Cat_Atributos cat_Atributos, Application.Cat_Atributos cat_Atributos1)
        {
            List<Models.Cat_Atributos> LstCat_Atributos = new List<Models.Cat_Atributos>();
            Models.Cat_Atributos BuquedaAtributo = new Models.Cat_Atributos();

            if (Session["AtributosArticulo"] != null)
            {
                LstCat_Atributos = (List<Models.Cat_Atributos>)Session["AtributosArticulo"];
            }

            BuquedaAtributo = cat_Atributos1.Atributo_Buscar_Id(cat_Atributos);
            if (BuquedaAtributo.Id> 0)
            {
                BuquedaAtributo.Valor = "";
                LstCat_Atributos.Add(BuquedaAtributo);
            }
            
            Session["AtributosArticulo"] = LstCat_Atributos;


            return Json(LstCat_Atributos);
        }
        [HttpPost]
        public JsonResult AtributoArticulo_Actualizar(Models.Cat_Atributos cat_Atributos)
        {
            List<Models.Cat_Atributos> LstCat_Atributos = new List<Models.Cat_Atributos>();
            List<Models.Cat_Atributos> LstNuevaCat_Atributos = new List<Models.Cat_Atributos>();

            if (Session["AtributosArticulo"] != null)
            {
                LstCat_Atributos = (List<Models.Cat_Atributos>)Session["AtributosArticulo"];
            }

            foreach(var dt in LstCat_Atributos)
            {
                if (dt.Id == cat_Atributos.Id)
                {
                    dt.Valor = cat_Atributos.Valor;
                    LstNuevaCat_Atributos.Add(dt);
                }
                else
                {
                    LstNuevaCat_Atributos.Add(dt);
                }
            }

            Session["AtributosArticulo"] = LstNuevaCat_Atributos;

            return Json(LstCat_Atributos);
        }
        [HttpPost]
        public JsonResult AtributoArticulo_Eliminar(Models.Cat_Atributos cat_Atributos)
        {
            List<Models.Cat_Atributos> LstCat_Atributos = new List<Models.Cat_Atributos>();
            List<Models.Cat_Atributos> LstNuevaCat_Atributos = new List<Models.Cat_Atributos>();

            if (Session["AtributosArticulo"] != null)
            {
                LstCat_Atributos = (List<Models.Cat_Atributos>)Session["AtributosArticulo"];
            }

            foreach (var dt in LstCat_Atributos)
            {
                if (dt.Id == cat_Atributos.Id)
                {

                }
                else
                {
                    LstNuevaCat_Atributos.Add(dt);
                }
            }

            Session["AtributosArticulo"] = LstNuevaCat_Atributos;

            return Json(LstNuevaCat_Atributos);
        }
        [HttpPost]
        public JsonResult ConsultaImagenes()
        {
            List<Models.ArticuloImg> LstInmuebleImg = new List<Models.ArticuloImg>();

            if (Session["Imagenes"] != null)
            {
                LstInmuebleImg = (List<Models.ArticuloImg>)Session["Imagenes"];
            }

            Session["Imagenes"] = LstInmuebleImg;

            return Json(LstInmuebleImg);
        }
        [HttpPost]
        public JsonResult Articulo_registrar(Models.Articulo articulo, Application.Articulo ApArticulo, Application.Cat_Atributos cat_Atributos, Application.ArticuloImg articuloImg)
        {
            Models.Articulo Newarticulo = new Models.Articulo();
            List<Models.Cat_Atributos> LstCat_Atributos = new List<Models.Cat_Atributos>();
            List<Models.ArticuloImg> LstInmuebleImg = new List<Models.ArticuloImg>();

            if (Session["AtributosArticulo"] != null)
            {
                LstCat_Atributos = (List<Models.Cat_Atributos>)Session["AtributosArticulo"];
            }

            if (Session["Imagenes"] != null)
            {
                LstInmuebleImg = (List<Models.ArticuloImg>)Session["Imagenes"];
            }


            Newarticulo = ApArticulo.Articulo_registrar(articulo);

            if (Newarticulo.Id>0)
            {
                foreach (var dt in LstCat_Atributos)
                {
                    dt.IdArticulo = Newarticulo.Id;
                    cat_Atributos.Articulo_Atributo_registrar(dt);
                }

                foreach (var dt in LstInmuebleImg)
                {
                    dt.IdArticulo = Newarticulo.Id;
                    articuloImg.Articulo_Imagen_registrar(dt);
                }
            }

           

            return Json(Newarticulo);
        }



    }
}
