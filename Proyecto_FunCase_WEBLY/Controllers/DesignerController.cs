using IdentitySample.Models;
using Proyecto_FunCase_WEBLY.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_FunCase_WEBLY.Controllers
{
    [Authorize]
    public class DesignerController : Controller
    {
        FunCaseModelContext db = new FunCaseModelContext();
        // GET: Designer
        public ActionResult Index()
        {
            ViewBag.Initial = 0;
            return View(db.Designers.ToList());
        }

        // GET: Designer/Details/5
        [Authorize(Roles = "Empleado,Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designer designer = db.Designers.Find(id);
            if (designer == null)
            {
                return HttpNotFound();
            }
            return View(designer);
        }

        [Authorize(Roles = "Diseñador")]
        public ActionResult Profile(int id)
        {
            Designer designer = db.Designers.Find(id);
            if (designer == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Profile", designer);
        }

        // GET: Designer/Create
        /*public ActionResult Create()
        {
            return View();
        }

        // POST: Designer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/

        // GET: Designer/Edit/5
        /*public ActionResult Edit(int id)
        {
            Designer designer = db.Designers.Single(d => d.DesignerID == id);
            return View(designer);
        }

        // POST: Designer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/

        [Authorize(Roles = "Diseñador")]
        public ActionResult EditProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Designer designer = db.Designers.Find(id);

            return PartialView("_EditProfile", designer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Designer designer)
        {
            try
            {
                Designer objDesigner = db.Designers.Find(designer.DesignerID);
                ApplicationUser userDesigner = db.Users.Find(designer.UserId);

                userDesigner.Nombre = designer.User.Nombre;
                userDesigner.Apellido1 = designer.User.Apellido1;
                userDesigner.Apellido2 = designer.User.Apellido2;
                userDesigner.Telefono = designer.User.Telefono;
                userDesigner.Email = designer.User.Email;

                db.Entry(userDesigner).State = EntityState.Modified;
                db.SaveChanges();

                objDesigner.NombrePresentacion = designer.NombrePresentacion;
                objDesigner.User = userDesigner;

                db.Entry(objDesigner).State = EntityState.Modified;
                db.SaveChanges();

                return View("Index", db.Designers.ToList());
            }
            catch
            {
                var designers = new List<Designer>();
                designers.Add(designer);
                ViewBag.Initial = 1;
                return View("Index", designers);
            }
        }

        // GET: Designer/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designer designer = db.Designers.Find(id);
            if (designer == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: Designer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Designer designer = db.Designers.Find(id);
                designer.Estatus = false;
                db.Entry(designer).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
