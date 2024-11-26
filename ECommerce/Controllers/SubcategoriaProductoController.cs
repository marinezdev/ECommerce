using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace ECommerce.Controllers
{
    public class SubcategoriaProductoController : Controller
    {
        // GET: SubcategoriaProductos
        public ActionResult Index(Application.Cat_TiendaPromo Acat_TiendaPromo, Application.Cat_Subcategoria Acat_SubCategoriaProducto)
        {
            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            Models.Cat_Subcategoria cat_Subcategoria = new Models.Cat_Subcategoria();
            cat_Subcategoria.Id = Id;

            ViewBag.Promos = Acat_TiendaPromo.Cat_TiendaPromo_Listar(3);

            ViewBag.SubCategorias = Acat_SubCategoriaProducto.Cat_Subcategoria_PorId(cat_Subcategoria);

            return View();
        }
    }
}