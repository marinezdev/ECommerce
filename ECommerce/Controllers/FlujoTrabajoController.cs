using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class FlujoTrabajoController : Controller
    {
        Models.Usuarios Usuairo = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
        // GET: FlujoTrabajo
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
        public JsonResult Flujo_Agregar(Models.Flujo flujo, Application.Flujo ApFlujo)
        {
            Models.Flujo ResulFlujo = ApFlujo.Flujo_Agregar(flujo);
            Session["NuevoFlujo"] = null;
            Session["NuevoUsuarioFlujoEtapas"] = null;
            return Json(ResulFlujo);
        }

        [HttpPost]
        public JsonResult Cat_FlujoBase_Listar(Models.Flujo flujo, Application.Cat_FlujoBase cat_FlujoBase)
        {
            List<Models.Cat_FlujoBase> ResulFlujoBase = cat_FlujoBase.Cat_FlujoBase_Listar(flujo);
            Session["NuevoFlujo"] = ResulFlujoBase;
            return Json(ResulFlujoBase);
        }

        [HttpPost]
        public JsonResult Etapa_Agregar(Models.Cat_FlujoBase cat_FlujoBase)
        {
            List<Models.Cat_FlujoBase> Etapas = new List<Models.Cat_FlujoBase>();
            
            if (Session["NuevoFlujo"] != null)
            {
                Etapas = (List<Models.Cat_FlujoBase>)Session["NuevoFlujo"];
            }

            bool busqueda = false;
            foreach(var dt in Etapas)
            {
                if(cat_FlujoBase.Nombre == dt.Nombre)
                {
                    busqueda = true;
                }
            }

            if(!busqueda)
            {
                cat_FlujoBase.Etapa = Etapas.Count + 1;
                if (Etapas.Count == 0)
                {
                    cat_FlujoBase.Id = 1;
                    cat_FlujoBase.IdFlujo = Etapas[0].IdFlujo;
                }
                else
                {
                    cat_FlujoBase.Id = Etapas.Max(x => x.Id) + 1;
                    cat_FlujoBase.IdFlujo = Etapas[0].IdFlujo;
                }
                
                Etapas.Add(cat_FlujoBase);

                Session["NuevoFlujo"] = Etapas;
            }
            else
            {
                Session["NuevoFlujo"] = Etapas;
            }

            return Json(Etapas);
        }

        [HttpPost]
        public JsonResult Etapa_Eliminar(Models.Cat_FlujoBase cat_FlujoBase)
        {
            List<Models.Cat_FlujoBase> Etapas = new List<Models.Cat_FlujoBase>();
            List<Models.Cat_FlujoBase> NuevaEtapas = new List<Models.Cat_FlujoBase>();
            if (Session["NuevoFlujo"] != null)
            {
                Etapas = (List<Models.Cat_FlujoBase>)Session["NuevoFlujo"];
            }

            if (Etapas.Count > 1)
            {
                for (int i = 0; i < Etapas.Count; i++)
                {
                    if (cat_FlujoBase.Id == Etapas[i].Id)
                    {
                        Etapas.Remove(Etapas[i]);
                    }
                }

            }

            for (int i = 0; i < Etapas.Count; i++)
            {
                Etapas[i].Etapa = i + 1;
                NuevaEtapas.Add(Etapas[i]);
            }

            Session["NuevoFlujo"] = NuevaEtapas;

            return Json(NuevaEtapas);
        }

        [HttpPost]
        public JsonResult Etapa_Subir(Models.Cat_FlujoBase cat_FlujoBase)
        {
            List<Models.Cat_FlujoBase> Etapas = new List<Models.Cat_FlujoBase>();
            List<Models.Cat_FlujoBase> NuevaEtapas = new List<Models.Cat_FlujoBase>();
            List<Models.Cat_FlujoBase> ReturnEtapas = new List<Models.Cat_FlujoBase>();

            Models.Cat_FlujoBase EtapasSelect = new Models.Cat_FlujoBase();

            if (Session["NuevoFlujo"] != null)
            {
                Etapas = (List<Models.Cat_FlujoBase>)Session["NuevoFlujo"];
            }

            for (int i = 0; i < Etapas.Count; i++)
            {
                if (cat_FlujoBase.Id == Etapas[i].Id)
                {
                    EtapasSelect = Etapas[i];
                    Etapas.Remove(Etapas[i]);
                }
            }

            for (int i = 0; i < Etapas.Count; i++)
            {
                if ((EtapasSelect.Etapa - 1) ==  Etapas[i].Etapa)
                {
                    NuevaEtapas.Add(EtapasSelect);
                    NuevaEtapas.Add(Etapas[i]);

                }
                else
                {
                    NuevaEtapas.Add(Etapas[i]);
                }
            }

            for (int i = 0; i < NuevaEtapas.Count; i++)
            {
                NuevaEtapas[i].Etapa = i + 1;
                ReturnEtapas.Add(NuevaEtapas[i]);
            }
            
            Session["NuevoFlujo"] = ReturnEtapas;

            return Json(NuevaEtapas);
        }

        [HttpPost]
        public JsonResult Etapa_Bajar(Models.Cat_FlujoBase cat_FlujoBase)
        {
            List<Models.Cat_FlujoBase> Etapas = new List<Models.Cat_FlujoBase>();
            List<Models.Cat_FlujoBase> NuevaEtapas = new List<Models.Cat_FlujoBase>();
            List<Models.Cat_FlujoBase> ReturnEtapas = new List<Models.Cat_FlujoBase>();

            Models.Cat_FlujoBase EtapasSelect = new Models.Cat_FlujoBase();

            if (Session["NuevoFlujo"] != null)
            {
                Etapas = (List<Models.Cat_FlujoBase>)Session["NuevoFlujo"];
            }

            for (int i = 0; i < Etapas.Count; i++)
            {
                if (cat_FlujoBase.Id == Etapas[i].Id)
                {
                    EtapasSelect = Etapas[i];
                    Etapas.Remove(Etapas[i]);
                }
            }

            for (int i = 0; i < Etapas.Count; i++)
            {
                if ((EtapasSelect.Etapa +1 ) == Etapas[i].Etapa)
                {
                    NuevaEtapas.Add(Etapas[i]);

                    NuevaEtapas.Add(EtapasSelect);
                }
                else
                {
                    NuevaEtapas.Add(Etapas[i]);
                }
            }

            for (int i = 0; i < NuevaEtapas.Count; i++)
            {
                NuevaEtapas[i].Etapa = i + 1;
                ReturnEtapas.Add(NuevaEtapas[i]);
            }

            Session["NuevoFlujo"] = ReturnEtapas;

            return Json(NuevaEtapas);
        }

        [HttpPost]
        public JsonResult EtapaUsuarios(Models.Cat_FlujoBase cat_FlujoBase)
        {
            List<Models.Cat_FlujoBase> UsuarioFlujoEtapas = new List<Models.Cat_FlujoBase>();
            List<Models.Cat_FlujoBase> NewUsuarioFlujoEtapas = new List<Models.Cat_FlujoBase>();

            if (Session["NuevoUsuarioFlujoEtapas"] != null)
            {
                UsuarioFlujoEtapas = (List<Models.Cat_FlujoBase>)Session["NuevoUsuarioFlujoEtapas"];
            }

            foreach (var dt in UsuarioFlujoEtapas)
            {
                if (cat_FlujoBase.Etapa == dt.Etapa)
                {
                    NewUsuarioFlujoEtapas.Add(dt);
                }
                
            }

            return Json(NewUsuarioFlujoEtapas);
        }

        [HttpPost]
        public JsonResult Usuarios_listar_Asignacion(Models.EtapasUsuario etapasUsuario, Application.EtapasUsuario etapasUsuario1)
        {
            List<Models.EtapasUsuario> ListUsuarios = etapasUsuario1.Usuarios_listar_Asignacion(etapasUsuario);

            return Json(ListUsuarios);
        }

        [HttpPost]
        public JsonResult EtapaUsuarios_Existencia(Models.EtapasUsuario etapasUsuario)
        {
            bool result = false;
            List<Models.Cat_FlujoBase> UsuarioFlujoEtapas = new List<Models.Cat_FlujoBase>();

            if (Session["NuevoUsuarioFlujoEtapas"] != null)
            {
                UsuarioFlujoEtapas = (List<Models.Cat_FlujoBase>)Session["NuevoUsuarioFlujoEtapas"];
            }

            foreach (var dt in UsuarioFlujoEtapas)
            {
                if(etapasUsuario.IdUsuario == dt.IdUsuario)
                {
                    if (etapasUsuario.IdEtapa == dt.Etapa)
                    {
                        result = true;
                        break;
                    }
                }
            }

            return Json(result);
        }

        [HttpPost]
        public JsonResult EtapaUsuarios_Agregar(Models.EtapasUsuario etapasUsuario, Application.Usuario usuario)
        {
            List<Models.Cat_FlujoBase> UsuarioFlujoEtapas = new List<Models.Cat_FlujoBase>();
            Models.Cat_FlujoBase cat_FlujoBaseNuw = new Models.Cat_FlujoBase();
            List<Models.Cat_FlujoBase> NewUsuarioFlujoEtapas = new List<Models.Cat_FlujoBase>();

            if (Session["NuevoUsuarioFlujoEtapas"] != null)
            {
                UsuarioFlujoEtapas = (List<Models.Cat_FlujoBase>)Session["NuevoUsuarioFlujoEtapas"];
            }

            cat_FlujoBaseNuw.IdUsuario = etapasUsuario.IdUsuario;
            cat_FlujoBaseNuw.Etapa = etapasUsuario.IdEtapa;
            cat_FlujoBaseNuw.Usuario = usuario.Consulta_Usuario_Nombre(etapasUsuario.IdUsuario).Nombre;
            UsuarioFlujoEtapas.Add(cat_FlujoBaseNuw);

            Session["NuevoUsuarioFlujoEtapas"] = UsuarioFlujoEtapas;

            foreach (var dt in UsuarioFlujoEtapas)
            {
                if (etapasUsuario.IdEtapa == dt.Etapa)
                {
                    NewUsuarioFlujoEtapas.Add(dt);
                }

            }


            return Json(NewUsuarioFlujoEtapas);
        }

        [HttpPost]
        public JsonResult EtapaUsuarios_Eliminar(Models.EtapasUsuario etapasUsuario)
        {
            List<Models.Cat_FlujoBase> UsuarioFlujoEtapas = new List<Models.Cat_FlujoBase>();
            List<Models.Cat_FlujoBase> NewUsuarioFlujoEtapas = new List<Models.Cat_FlujoBase>();
            List<Models.Cat_FlujoBase> UsuarioFlujoEtapasList = new List<Models.Cat_FlujoBase>();

            if (Session["NuevoUsuarioFlujoEtapas"] != null)
            {
                UsuarioFlujoEtapas = (List<Models.Cat_FlujoBase>)Session["NuevoUsuarioFlujoEtapas"];
            }

            foreach (var dt in UsuarioFlujoEtapas)
            {
                if (etapasUsuario.IdEtapa == dt.Etapa)
                {
                    if (etapasUsuario.IdUsuario == dt.IdUsuario)
                    {
                        // No agregar a la lista
                    }
                    else
                    {
                        NewUsuarioFlujoEtapas.Add(dt);
                    }
                }
                else
                {
                    NewUsuarioFlujoEtapas.Add(dt);
                }

            }

            Session["NuevoUsuarioFlujoEtapas"] = NewUsuarioFlujoEtapas;

            foreach (var dt in NewUsuarioFlujoEtapas)
            {
                if (etapasUsuario.IdEtapa == dt.Etapa)
                {
                    UsuarioFlujoEtapasList.Add(dt);
                }

            }


            return Json(UsuarioFlujoEtapasList);
        }


        [HttpPost]
        public JsonResult EtapaUsuarios_Registrar(Application.Etapas etapas, Application.EtapasUsuario etapasUsuario)
        {
            int result = 1;

            List<Models.Cat_FlujoBase> Etapas = new List<Models.Cat_FlujoBase>();
            List<Models.Cat_FlujoBase> UsuarioFlujoEtapas = new List<Models.Cat_FlujoBase>();

            if (Session["NuevoFlujo"] != null)
            {
                Etapas = (List<Models.Cat_FlujoBase>)Session["NuevoFlujo"];
            }
            else
            {
                result = 0;
            }

            if (Session["NuevoUsuarioFlujoEtapas"] != null)
            {
                UsuarioFlujoEtapas = (List<Models.Cat_FlujoBase>)Session["NuevoUsuarioFlujoEtapas"];
            }
            else
            {
                result = -1;
            }

            if (result == 1)
            {
                foreach (var dt in Etapas)
                {
                    // REGISTRA ETAPAS
                    int IdEtapa = etapas.Etapas_Agregar(dt).Id;

                    if (IdEtapa > 0)
                    {
                        // REGISTRA USUARIO ETAPAS
                        foreach (var dtUsuarios in UsuarioFlujoEtapas)
                        {
                            if (dt.Etapa == dtUsuarios.Etapa)
                            {
                                Models.Cat_FlujoBase NewEtapa = new Models.Cat_FlujoBase();
                                NewEtapa.IdUsuario = dtUsuarios.IdUsuario;
                                NewEtapa.Etapa = IdEtapa;
                                //NewEtapa.Orden = dt.Etapa;
                                etapasUsuario.EtapasUsuarios_Agregar(NewEtapa);
                            }
                        }
                    }
                }
            }
            


            return Json(result);
        }
    }
}
