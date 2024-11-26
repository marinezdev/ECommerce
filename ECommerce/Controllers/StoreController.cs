using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index(Application.Articulo articulo)
        {
            ViewBag.Articulos = articulo.Articulos_Store_Listar();

            return View();
        }
        [HttpPost]
        public JsonResult Agregar_Carrito(Models.Carro_Electronico carro_Electronico, Application.Carro_Electronico APcarro_Electronico, Application.Cookie_Carrito cookie_Carrito)
        {
            Models.Mensaje mensaje = new Models.Mensaje();
             
            string dt = "";
            if (Request.Cookies["Carrito"] != null)
            {
                dt = Application.UrlCifrardo.Decrypt(Request.Cookies["Carrito"].Value.ToString());
                mensaje = APcarro_Electronico.Carro_Electronico_Registrar_Articulo(dt, carro_Electronico);
            }
            else
            {
                Models.Cookie_Carrito cookie_Carrito1 = cookie_Carrito.Cookie_Carrito_Registrar();
                Response.Cookies["Carrito"].Value = Application.UrlCifrardo.Encrypt(cookie_Carrito1.Clave);
                mensaje = APcarro_Electronico.Carro_Electronico_Registrar_Articulo(cookie_Carrito1.Clave, carro_Electronico);
            }

            return Json(mensaje);
        }
        [HttpPost]
        public JsonResult Carrito_Consultar(Application.Carro_Electronico carro_Electronico)
        {
            Models.Carro_Electronico comp = new Models.Carro_Electronico();
            string dt = "";
            comp.Total = 0;
            if (Request.Cookies["Carrito"] != null)
            {
                dt = Application.UrlCifrardo.Decrypt(Request.Cookies["Carrito"].Value.ToString());
                comp = carro_Electronico.Carro_Electronico_Consultar_Total(dt);
            }
            return Json(comp);
        }
        [HttpPost]
        public JsonResult Carrito_Listar(Application.Carro_Electronico carro_Electronico)
        {
            List<Models.Carro_Electronico> Lista = new List<Models.Carro_Electronico>();
            string dt = "";
            if (Request.Cookies["Carrito"] != null)
            {
                dt = Application.UrlCifrardo.Decrypt(Request.Cookies["Carrito"].Value.ToString());
                Lista = carro_Electronico.Carro_Electronico_Listar_Articulos(dt);
            }
            return Json(Lista);
        }
        [HttpPost]
        public JsonResult Eliminar_Articulo(Models.Carro_Electronico carro_Electronico, Application.Carro_Electronico APcarro_Electronico1)
        {
            Models.Mensaje mensaje = new Models.Mensaje();
            string dt = "";
            if (Request.Cookies["Carrito"] != null)
            {
                dt = Application.UrlCifrardo.Decrypt(Request.Cookies["Carrito"].Value.ToString());
                mensaje = APcarro_Electronico1.Carrito_Eliminar_Articulo(dt, carro_Electronico);
            }

            return Json(mensaje);
        }
        [HttpPost]
        public JsonResult Actualizar_Carrito(Models.Carro_Electronico carro_Electronico, Application.Carro_Electronico APcarro_Electronico)
        {
            string clave = "";
            Models.Carro_Electronico dtCarrito = new Models.Carro_Electronico();
            if (Request.Cookies["Carrito"] != null)
            {
                clave = Application.UrlCifrardo.Decrypt(Request.Cookies["Carrito"].Value.ToString());
                dtCarrito = APcarro_Electronico.Carrito_Actualizar(clave, carro_Electronico);
            }
            return Json(dtCarrito);
        }
        public ActionResult Carro(Application.Carro_Electronico carro_Electronico)
        {
            List<Models.Carro_Electronico> Lista = new List<Models.Carro_Electronico>();
            string clave = "";
            if (Request.Cookies["Carrito"] != null)
            {
                clave = Application.UrlCifrardo.Decrypt(Request.Cookies["Carrito"].Value.ToString());
                Lista = carro_Electronico.Carro_Electronico_Listar_Articulos(clave);
            }

            string TotalText = "0.0";
            decimal Precio = 0;
            foreach (var dt in Lista)
            {
                Precio += (Convert.ToDecimal(dt.Item) * Convert.ToDecimal(dt.Precio));
            }
            string s = string.Format("{0:N2}", Precio); // No fear of rounding and takes the default number format
            //String s = String.Format("{0:#,##0.##}", Precio);

            ViewBag.Total = s;
            ViewBag.ListaArticulos = Lista;

            return View();
        }



        public ActionResult ArticuloDetalle(Application.ArticuloImg articuloImg, Application.Articulo AParticulo , Application.ArticulosAtributos AParticulosAtributos)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["Arti"]))
            {
                Models.Articulo articulo = new Models.Articulo();
                articulo.Id = Convert.ToInt32(Request.QueryString["Arti"].ToString());

                List<Models.ArticuloImg> articuloImgs = articuloImg.ArticuloImgs_Seleccionar_IdArticulo(articulo);
                Models.Consultas.ArticuloConsulta dtArticulo = AParticulo.Articulo_Selecionar_IdArticulo(articulo);
                List<Models.Consultas.ArticuloAtributos> articuloAtributos = AParticulosAtributos.Articulo_Atributos_Selecionar(articulo);

                ViewBag.Imgs = articuloImgs;
                ViewBag.ArticuloConsulta = dtArticulo;
                ViewBag.ArticuloAtributos = articuloAtributos;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Store");
            }
                
            
        }
    }
}
