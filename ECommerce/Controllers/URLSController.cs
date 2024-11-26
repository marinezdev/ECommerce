using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class URLSController : Controller
    {
        [HttpPost]

        public JsonResult URL_Cifrar(Models.URL uRL)
        {
            Models.URL NewUrl = new Models.URL();
            NewUrl.Url = Application.UrlCifrardo.Encrypt(uRL.UrlVaible);
            return Json(NewUrl);
        }
    }
}