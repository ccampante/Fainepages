using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fainepages.Controllers
{
    public class TemplateController : Controller
    {
        // GET: Template
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConfiguraTemplate()
        {
            return View();
        }

        public ActionResult ConfiguraAtributos()
        {
            return View();
        }

        public ActionResult UploadArquivos()
        {
            return View();
        }

        public ActionResult Conclusao()
        {
            return View();
        }
    }
}