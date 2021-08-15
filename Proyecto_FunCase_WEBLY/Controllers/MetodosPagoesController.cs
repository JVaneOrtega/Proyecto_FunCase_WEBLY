using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_FunCase_WEBLY.Models;

namespace Proyecto_FunCase_WEBLY.Controllers
{
    public class MetodosPagoesController : Controller
    {
        private FunCaseModelContext db = new FunCaseModelContext();

        // GET: MetodosPagoes
        public ActionResult Index()
        {
            return View(db.MetodosPagos.ToList());
        }

        // GET: MetodosPagoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetodosPago metodosPago = db.MetodosPagos.Find(id);
            if (metodosPago == null)
            {
                return HttpNotFound();
            }
            return View(metodosPago);
        }

        // GET: MetodosPagoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MetodosPagoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MetodosPagoID,Nombre")] MetodosPago metodosPago)
        {
            if (ModelState.IsValid)
            {
                db.MetodosPagos.Add(metodosPago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(metodosPago);
        }

        // GET: MetodosPagoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetodosPago metodosPago = db.MetodosPagos.Find(id);
            if (metodosPago == null)
            {
                return HttpNotFound();
            }
            return View(metodosPago);
        }

        // POST: MetodosPagoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MetodosPagoID,Nombre")] MetodosPago metodosPago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metodosPago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(metodosPago);
        }

        // GET: MetodosPagoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetodosPago metodosPago = db.MetodosPagos.Find(id);
            if (metodosPago == null)
            {
                return HttpNotFound();
            }
            return View(metodosPago);
        }

        // POST: MetodosPagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MetodosPago metodosPago = db.MetodosPagos.Find(id);
            db.MetodosPagos.Remove(metodosPago);
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
