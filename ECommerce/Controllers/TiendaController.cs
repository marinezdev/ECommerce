using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class TiendaController : Controller
    {
        // GET: Tienda
        public ActionResult Index(Application.Cat_TiendaPromo Acat_TiendaPromo, Application.Cat_CategoriaProducto Acat_CategoriaProducto)
        {
            ViewBag.Promos = Acat_TiendaPromo.Cat_TiendaPromo_Listar(1);
            ViewBag.Categorias = Acat_CategoriaProducto.Cat_CategoriaProducto_Listar();

            return View();
        }
    }
}