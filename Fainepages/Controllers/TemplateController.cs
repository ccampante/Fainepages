using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fainepages.Models;

namespace Fainepages.Controllers
{
    public class TemplateController : Controller
    {

        private FPModel db = new FPModel();

        // GET: Template
        public ActionResult Index()
        {
            return View(db.Template.ToList());
        }

        // GET
        public ActionResult ConfiguraTemplate()
        {
            return View();
        }

        // POST: ConfiguraTemplate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfiguraTemplate([Bind(Include = "TemplateId,Titulo,Url,MetaDescricao,PalavrasChaves,Formulario,Analytics,TagManager,Smartlook")] Template template)
        {
            if (ModelState.IsValid)
            {
                template.DtCriacao = DateTime.Now;
                db.Template.Add(template);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(template);
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