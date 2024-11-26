using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class Compra_DireccionController : Controller
    {
        // GET: Compra_Direccion
        public ActionResult Index(Application.Carro_Electronico carro_Electronico, Application.Cat_Estados cat_Estados)
        {
            if (Session["Sesion"] != null)
            {
                return RedirectToAction("IndexUser", "Compra_Direccion");
            }
            else
            {
                if (Session["SesionInvitacion"] != null)
                {
                    if (Request.Cookies["Carrito"] != null)
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
                        ViewBag.CatEstados = cat_Estados.Cat_Estados_Seleccionar();

                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Index", "Store");
                    }
                }
                else
                {
                    return RedirectToAction("Invitacion", "Adm");
                }
            }
        }

        [HttpPost]
        public JsonResult Consulta_Estados(Application.Cat_Estados cat_Estados)
        {
            List<Models.Cat_Estados> estados = cat_Estados.Cat_Estados_Seleccionar();
            return Json(estados);
        }

        [HttpPost]
        public JsonResult Consulta_DelegacionMunicipio(Models.Cat_Poblacion cat_Poblacion, Application.Cat_Poblacion APcatPoblacion)
        {
            List<Models.Cat_Poblacion> Poblaciones = APcatPoblacion.Cat_Poblaciones_Seleccionar(cat_Poblacion.Id);
            return Json(Poblaciones);
        }

        [HttpPost]
        public JsonResult Consulta_Colonias(Models.Cat_Colonias cat_Colonias, Application.Cat_Colonias APcat_Colonias)
        {
            List<Models.Cat_Colonias> Poblaciones = APcat_Colonias.Cat_Colonias_Seleccionar(cat_Colonias.Id);
            return Json(Poblaciones);
        }

        [HttpPost]
        public JsonResult Consulta_CP(Models.Cat_Colonias cat_Colonias, Application.Cat_CP catCP)
        {
            List<Models.Cat_CP> Poblaciones = catCP.Cat_CP_Seleccionar(cat_Colonias.Id);
            return Json(Poblaciones);
        }

        [HttpPost]
        public JsonResult CP_Busqueda(Models.Cat_CP cat_CP, Application.Cat_CP APcatCP)
        {
            List<Models.Usuarios_Direcciones> Poblaciones = APcatCP.Cat_CP_Busqueda(cat_CP.CP);
            return Json(Poblaciones);
        }




        public ActionResult IndexUser(Application.Carro_Electronico carro_Electronico, Application.Cat_Estados cat_Estados, Application.Menu menu, Application.Usuarios_Direcciones usuarios)
        {
            
            if (Session["Sesion"] != null)
            {
                string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

                if (menu.ValidacionPagina(Usuario, url))
                {
                    if (Request.Cookies["Carrito"] != null)
                    {
                        List<Models.Carro_Electronico> Lista = new List<Models.Carro_Electronico>();
                        List<Models.Usuarios_Direcciones> ListaDireciones = usuarios.Usuarios_Direcciones_Selecionar_IdUsuario(Usuario);

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
                        ViewBag.CatEstados = cat_Estados.Cat_Estados_Seleccionar();
                        ViewBag.ListaDireciones = ListaDireciones;
                        ViewBag.Usuario = Usuario;

                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Index", "Store");
                    }
                }
                else
                {
                    return RedirectToAction("Invitacion", "Adm");
                }
            }
            else
            {
                return RedirectToAction("Invitacion", "Adm");
            }
        }

        [HttpPost]
        public JsonResult Usuarios_Direcciones_Seleccionar(Models.Usuarios_Direcciones usuarios_Direcciones, Application.Usuarios_Direcciones APusuarios_Direcciones)
        {
            Models.Usuarios Usuairo = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            Models.Usuarios_Direcciones direccion = APusuarios_Direcciones.Usuarios_Direcciones_Seleccionar_Id(usuarios_Direcciones.Id);
            if (direccion.RecibirPedido == 0)
            {
                direccion.Recibe_Nombre = Usuairo.Nombre;
                direccion.Recibe_Apellidos = Usuairo.Apellidos;
                direccion.Recibe_Telefono = Usuairo.Telefono;
                direccion.TipoTelefono = Usuairo.TipoTelefono;
            }

            return Json(direccion);
        }

        //// METODO DIRECCION SELECIONADA
        ///

        [HttpPost]
        public JsonResult Venta_Direcciones_Selecionar(Models.Usuarios_Direcciones usuarios_Direcciones, Application.Venta venta)
        {
            string Clave = "";
            Models.Cliente cliente = new Models.Cliente();
            if (Request.Cookies["Carrito"] != null)
            {
                Models.Usuarios Usuairo = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
                Clave = Application.UrlCifrardo.Decrypt(Request.Cookies["Carrito"].Value.ToString());
                usuarios_Direcciones.IdUsuario = Usuairo.IdUsuario;
                cliente = venta.Venta_Direcciones_Seleccionar(usuarios_Direcciones, Clave);
            }
            else
            {
                cliente.Id = 0;
            }
            return Json(cliente);
        }


        


        //// METODO PARA AGREGAR UNA NUEVA DIRECCION
        ///
        //// METODO PARA ACTUALIZAR UNA DIRECCION

    }
}
