using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using Proyecto_FunCase_WEBLY.Models;

namespace Proyecto_FunCase_WEBLY.Controllers
{
    [Authorize(Roles = "Empleado")]
    public class ModeloesController : Controller
    {
        private FunCaseModelContext db = new FunCaseModelContext();

        // GET: Modeloes
        public ActionResult Index()
        {
            return View(db.Modelos.Include(m => m.Marca).ToList());
        }

        // GET: Modeloes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = db.Modelos.Find(id);
            if (modelo == null)
            {
                return HttpNotFound();
            }
            return View(modelo);
        }

        [Authorize(Roles = "Empleado")]
        // GET: Modeloes/Create
        public ActionResult Create()
        {
            ViewBag.MarcaID = new SelectList(db.Marcas, "MarcaID", "Nombre");
            return View();
        }

        // POST: Modeloes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Modelo modelo)
        {
            if (ModelState.IsValid)
            {
                string ruta = Path.Combine(Server.MapPath("~/Images/Modelos/"+modelo.MarcaID));
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }

                foreach (string file in Request.Files)
                {
                    HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                    if (hpf.ContentLength == 0)
                        continue;
                    string savedFileName = Path.Combine(ruta, Path.GetFileName(hpf.FileName));
                    hpf.SaveAs(savedFileName);
                    modelo.ImagenReferencia = String.Concat("/Images/Modelos/", modelo.MarcaID.ToString(),"/", hpf.FileName);
                }

                db.Modelos.Add(modelo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Modeloes/Edit/5
        [Authorize(Roles = "Empleado")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = db.Modelos.Find(id);
            if (modelo == null)
            {
                return HttpNotFound();
            }
            ViewBag.MarcaID = new SelectList(db.Marcas, "MarcaID", "Nombre");
            return View(modelo);
        }

        // POST: Modeloes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Modelo modelo)
        {
            if (ModelState.IsValid)
            {
                string ruta = Path.Combine(Server.MapPath("~/Images/Modelos/" + modelo.MarcaID));
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }

                foreach (string file in Request.Files)
                {
                    HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                    if (hpf.ContentLength == 0)
                        break;
                    string savedFileName = Path.Combine(ruta, Path.GetFileName(hpf.FileName));
                    hpf.SaveAs(savedFileName);
                    modelo.ImagenReferencia = String.Concat("/Images/Modelos/", modelo.MarcaID.ToString(), "/", hpf.FileName);
                }

                db.Entry(modelo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        [Authorize(Roles = "Empleado")]
        // GET: Modeloes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = db.Modelos.Find(id);
            if (modelo == null)
            {
                return HttpNotFound();
            }
            return View(modelo);
        }

        // POST: Modeloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modelo modelo = db.Modelos.Find(id);
            modelo.Estatus = false;
            db.Entry(modelo).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
