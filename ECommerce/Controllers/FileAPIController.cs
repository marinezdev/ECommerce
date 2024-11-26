using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ECommerce.Controllers
{
    public class FileAPIController : ApiController
    {
        // GET: FileAPI
        [Route("api/FileAPI/UploadFilesSubCategoria")]
        [HttpPost]
        public HttpResponseMessage UploadFiles()
        {
            string DirectorioUsuario = HttpContext.Current.Server.MapPath("~") + "\\Articulos\\SubCategorias\\";
            string DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\Articulos\\SubCategorias\\";
            Application.Control_Archivos control_Archivos = new Application.Control_Archivos();
            List<Models.ArticuloImg> LstArticuloImg = new List<Models.ArticuloImg>();

            for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
            {
                HttpPostedFile POT = HttpContext.Current.Request.Files[i];
                Models.ArticuloImg _inmueblesImg = new Models.ArticuloImg();
                _inmueblesImg = control_Archivos.NuevoArchivo(POT, DirectorioUsuario, DirectorioURL);
                if (_inmueblesImg.NmArchivo != null)
                {
                    LstArticuloImg.Add(_inmueblesImg);
                }
            }

            //Send OK Response to Client.
            return Request.CreateResponse(HttpStatusCode.OK, LstArticuloImg);
        }

        [Route("api/FileAPI/UploadFilesClasificacion")]
        [HttpPost]
        public HttpResponseMessage UploadFilesClasificacion()
        {
            string DirectorioUsuario = HttpContext.Current.Server.MapPath("~") + "\\Articulos\\Clasificacion\\";
            string DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\Articulos\\Clasificacion\\";
            Application.Control_Archivos control_Archivos = new Application.Control_Archivos();
            List<Models.ArticuloImg> LstArticuloImg = new List<Models.ArticuloImg>();

            for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
            {
                HttpPostedFile POT = HttpContext.Current.Request.Files[i];
                Models.ArticuloImg _inmueblesImg = new Models.ArticuloImg();
                _inmueblesImg = control_Archivos.NuevoArchivo(POT, DirectorioUsuario, DirectorioURL);
                if (_inmueblesImg.NmArchivo != null)
                {
                    LstArticuloImg.Add(_inmueblesImg);
                }
            }

            //Send OK Response to Client.
            return Request.CreateResponse(HttpStatusCode.OK, LstArticuloImg);
        }

        // GET: FileAPI
        [Route("api/FileAPI/UploadFilesArticulo")]
        [HttpPost]
        public HttpResponseMessage UploadFilesArticulo()
        {
            string DirectorioUsuario = HttpContext.Current.Server.MapPath("~") + "\\Articulos\\";
            string DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\Articulos\\";
            Application.Control_Archivos control_Archivos = new Application.Control_Archivos();
            List<Models.ArticuloImg> LstArticuloImg = new List<Models.ArticuloImg>();

            for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
            {
                HttpPostedFile POT = HttpContext.Current.Request.Files[i];
                Models.ArticuloImg _inmueblesImg = new Models.ArticuloImg();
                _inmueblesImg = control_Archivos.NuevoArchivo(POT, DirectorioUsuario, DirectorioURL);
                if (_inmueblesImg.NmArchivo != null)
                {
                    LstArticuloImg.Add(_inmueblesImg);
                }
            }

            //Send OK Response to Client.
            return Request.CreateResponse(HttpStatusCode.OK, LstArticuloImg);
        }

    }
}
