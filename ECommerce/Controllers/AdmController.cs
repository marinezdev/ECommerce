using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class AdmController : Controller
    {
        // GET: Adm
        /// <summary>
        /// prueba git
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public ActionResult Index(Application.Usuario usuario)
        {
            Models.Usuarios Usuairo = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

            if (Usuairo != null)
            {
                switch (Usuairo.IdRol)
                {
                    case 1:
                        return RedirectToAction("Index", "Administracion");
                    case 2:
                        return RedirectToAction("Index", "Operador");
                    default:
                        break;
                }
            }

            try
            {
                if (Request.Cookies["SesionDT"].Value != "")
                {
                    string Clave = Application.UrlCifrardo.Decrypt(Request.Cookies["SesionDT"].Value.ToString());
                    Models.Usuarios DtUsuer = usuario.coo_Session_Seleccionar(Clave);

                    if (DtUsuer.IdUsuario > 0)
                    {
                        Session["Sesion"] = DtUsuer;
                        Session["SesionInvitacion"] = null;
                        switch (DtUsuer.IdRol)
                        {
                            case 1:
                                return RedirectToAction("Index", "Administracion");
                            case 2:
                                return RedirectToAction("Index", "Operador");
                            default:
                                break;
                        }
                    }
                }
            }
            catch 
            {

            }
            
            ViewBag.rd = Request.QueryString["rd"];
            ViewBag.rdv = Request.QueryString["rdv"];
            return View();
        }

        [HttpPost]
        public JsonResult Iniciar(Models.NuevoRegistro NuevoUsuario, Application.Usuario usuario, Application.Menu menu)
        {
            if (NuevoUsuario != null)
            {
                Models.Usuarios DataUser = usuario.Iniciar(NuevoUsuario.usuarios);
                if (DataUser.IdUsuario > 0)
                {
                    Session["Sesion"] = DataUser;
                    Session["SesionInvitacion"] = null;
                    if (NuevoUsuario.usuarios.Session)
                    {
                        Response.Cookies["SesionDT"].Value = Application.UrlCifrardo.Encrypt(DataUser.ClaveCoo);
                    }
                }

                if (!String.IsNullOrEmpty(NuevoUsuario.usuarios.Ruta))
                {
                    string url = Application.UrlCifrardo.Decrypt(NuevoUsuario.usuarios.Ruta);
                    if (menu.ValidacionPagina(DataUser, url))
                    {
                        string Nu = Application.UrlCifrardo.Decrypt(NuevoUsuario.usuarios.RutaAcceso);
                        DataUser.RutaAcceso = Nu;
                    }
                }

                return Json(DataUser);
            }
            else
            {
                return Json("Ha ocurrido un problema!");
            }
        }

        [HttpPost]
        public JsonResult CerrarSesion()
        {
            Models.Usuarios DataUser = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
            Response.Cookies["SesionDT"].Value = null;

            Session.Abandon();

            if (DataUser != null)
            {
                return Json(DataUser);
            }
            else
            {
                return Json("Ha ocurrido un problema!");
            }
        }

        public ActionResult Invitacion(Application.Usuario usuario, Application.Carro_Electronico carro_Electronico)
        {
            if (Request.Cookies["Carrito"] != null)
            {
                if (carro_Electronico.Carro_Electronico_Listar_Articulos(Application.UrlCifrardo.Decrypt(Request.Cookies["Carrito"].Value.ToString())).Count > 0)
                {
                    if (Session["Sesion"] != null)
                    {
                        return RedirectToAction("IndexUser", "Compra_Direccion");
                    }
                    //else if (Session["SesionInvitacion"] != null)
                    //{
                    //    return RedirectToAction("Index", "Compra_Direccion");
                    //}
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return RedirectToAction("Carro", "Store");
                }
            }
            else
            {
                return RedirectToAction("Carro", "Store");
            }
                
        }

        [HttpPost]
        public JsonResult Agregar_Invitado(Application.Usuario usuario)
        {
            Models.Usuarios DataUser = new Models.Usuarios();
            DataUser.Invitacion = 1;
            Session["SesionInvitacion"] = DataUser;
            Session["Sesion"] = null;

            return Json(DataUser);
        }


        [HttpPost]
        public JsonResult Invitado_Agregar_Informacion(Models.Usuarios_Invitado usuarios_Invitado, Application.Usuarios_Invitado APusuarios_Invitado)
        {
            string Clave = "";
            Models.Cliente cliente = new Models.Cliente();
            if (Request.Cookies["Carrito"] != null)
            {
                Clave = Application.UrlCifrardo.Decrypt(Request.Cookies["Carrito"].Value.ToString());
                cliente = APusuarios_Invitado.Usuarios_Invitado_Agregar(Clave, usuarios_Invitado);
            }
            else
            {
                cliente.Id = 0;
            }
            return Json(cliente);
        }

        [HttpPost]
        public JsonResult Usuario_Agregar_Informacion(Models.Usuarios_Direcciones usuarios_Direcciones, Application.Usuarios_Direcciones APusuarios_Direcciones)
        {
            string Clave = "";
            Models.Cliente cliente = new Models.Cliente();
            if (Request.Cookies["Carrito"] != null)
            {
                Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
                Clave = Application.UrlCifrardo.Decrypt(Request.Cookies["Carrito"].Value.ToString());
                usuarios_Direcciones.IdUsuario = Usuario.IdUsuario;
                cliente = APusuarios_Direcciones.Usuarios_Direcciones_Agregar(Clave, usuarios_Direcciones);
            }
            else
            {
                cliente.Id = 0;
            }
            return Json(cliente);
        }


        [HttpPost]
        public JsonResult IniciarSesionCompra(Models.Usuarios usuarios, Application.Usuario usuario)
        {
            usuarios.Session = false;
            Models.Usuarios DataUser = usuario.Iniciar(usuarios);
            if (DataUser.IdUsuario > 0)
            {
                Session["Sesion"] = DataUser;
                Session["SesionInvitacion"] = null;
            }
            return Json(DataUser);
        }

        
    }
}
