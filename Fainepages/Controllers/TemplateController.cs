using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
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
        public ActionResult ConfiguraTemplate(int? id)
        {
            if (id != null)
            {
                Template template = db.Template.Find(id);
                if (template != null)
                {
                    return View(template);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
            {
                return View();
            }
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
                if (template.TemplateId > 0)
                {
                    //Update
                    db.Entry(template).State = EntityState.Modified;
                    db.Entry(template).Property(x => x.DtCriacao).IsModified = false;
                    db.Entry(template).Property(x => x.FormularioCode).IsModified = false;
                    db.Entry(template).Property(x => x.AnalyticsCode).IsModified = false;
                    db.Entry(template).Property(x => x.TagManagerCode).IsModified = false;
                    db.Entry(template).Property(x => x.SmartlookCode).IsModified = false;
                    db.SaveChanges();
                   
                    return RedirectToAction("ConfiguraAtributos", "Template", new { @id = template.TemplateId });
                }
                else
                {
                    //Insert
                    template.DtCriacao = DateTime.Now;
                    db.Template.Add(template);
                    db.SaveChanges();

                    db.Entry(template).GetDatabaseValues();
                    return RedirectToAction("ConfiguraAtributos", "Template", new { @id = template.TemplateId });
                }
                
            }
            else
            {
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
                var messageArray = this.ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors, (modelState, error) => error.ErrorMessage).ToArray();
            }

            return View(template);
        }

        // GET 
        public ActionResult ConfiguraAtributos(int? id)
        {
            if (id != null)
            {
                Template template = db.Template.Find(id);
                if (template != null)
                {
                    return View(template);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
            {
                //return View();
                return HttpNotFound();
            }
        }

        // POST: ConfiguraAtributos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfiguraAtributos(FormCollection collection)
        {
            try
            {
                int id = Convert.ToInt32(collection["TemplateId"]);
                string submit = collection["submit"];

                switch (submit)
                {
                    case "imagem":
                        // incluir alts

                        string alt = collection["alt"];

                        Atributo img = new Atributo();
                        img.TemplateId = id;
                        img.Texto = alt;
                        img.Tipo = Util.TipoAtributo.Imagem.ToString();

                        db.Atributo.Add(img);
                        db.SaveChanges();

                        return RedirectToAction("ConfiguraAtributos", "Template", new { @id = id });

                    case "video":
                        // incluir urls

                        string url = collection["url"];

                        Atributo vdo = new Atributo();
                        vdo.TemplateId = id;
                        vdo.Url = url;
                        vdo.Tipo = Util.TipoAtributo.Video.ToString();

                        db.Atributo.Add(vdo);
                        db.SaveChanges();

                        return RedirectToAction("ConfiguraAtributos", "Template", new { @id = id });

                    case "blink":
                        // incluir links

                        string link = collection["link"];
                        bool abreNovaGuia = collection["novaguia"] != null ? true : false; 

                        Atributo lnk = new Atributo();
                        lnk.TemplateId = id;
                        lnk.Url = link;
                        lnk.NovaGuia = abreNovaGuia;
                        lnk.Tipo = Util.TipoAtributo.Link.ToString();

                        db.Atributo.Add(lnk);
                        db.SaveChanges();

                        return RedirectToAction("ConfiguraAtributos", "Template", new { @id = id });

                    case "botao":
                        // incluir botões

                        string botaourl = collection["botaourl"];
                        string legenda = collection["legenda"];
                        bool botaoAbreNovaGuia = collection["botaonovaguia"] != null ? true : false;

                        Atributo btn = new Atributo();
                        btn.TemplateId = id;
                        btn.Texto = legenda;
                        btn.Url = botaourl;
                        btn.NovaGuia = botaoAbreNovaGuia;
                        btn.Tipo = Util.TipoAtributo.Botao.ToString();

                        db.Atributo.Add(btn);
                        db.SaveChanges();

                        return RedirectToAction("ConfiguraAtributos", "Template", new { @id = id });

                    case "avancar":
                        //continuar para step 3

                        string formulario = collection["FormularioCode"];
                        string ga = collection["AnalyticsCode"];
                        string gtm = collection["TagManagerCode"];
                        string smartlook = collection["SmartlookCode"];

                        //Update
                        Template temp = db.Template.Find(id);

                        temp.FormularioCode = formulario;
                        temp.AnalyticsCode = ga;
                        temp.TagManagerCode = gtm;
                        temp.SmartlookCode = smartlook;

                        db.Entry(temp).State = EntityState.Modified;
                        db.Entry(temp).Property(x => x.DtCriacao).IsModified = false;
                        db.SaveChanges();

                        return RedirectToAction("UploadArquivos", "Template", new { @id = id });

                    default:
                        
                        break;
                }

                return View();
            }
            catch
            {
                return View();
            }
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