using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class ClasificacionProductoController : Controller
    {
        // GET: Clasificacion
        public ActionResult Index(Application.Cat_TiendaPromo Acat_TiendaPromo, Application.Cat_Clasificacion Acat_Clasificacion)
        {
            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            Models.Cat_Clasificacion cat_Clasificacion = new Models.Cat_Clasificacion();
            cat_Clasificacion.Id = Id;

            ViewBag.Promos = Acat_TiendaPromo.Cat_TiendaPromo_Listar(2);

            ViewBag.Clasificacion = Acat_Clasificacion.Cat_Clasificacion_PorId(cat_Clasificacion);

            return View();
        }
    }
}