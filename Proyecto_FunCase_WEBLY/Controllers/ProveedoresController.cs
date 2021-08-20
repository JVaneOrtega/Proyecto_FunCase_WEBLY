using Proyecto_FunCase_WEBLY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_FunCase_WEBLY.Controllers
{
    [Authorize(Roles = "Empleado")]
    public class ProveedoresController : Controller
    {
        FunCaseModelContext db = new FunCaseModelContext();
        // GET: Proveedores
        public ActionResult Index()
        {
            return View(db.Proveedores.ToList());
        }

        // GET: Proveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedores.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            
            return View(proveedor);
        }

        // GET: Proveedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedores/Create
        [HttpPost]
        public ActionResult Create(Proveedor proveedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Proveedores.Add(proveedor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(proveedor);
            }
            catch
            {
                return View(proveedor);
            }
        }

        // GET: Proveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedores.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: Proveedores/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Proveedor proveedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(proveedor).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(proveedor);
            }
            catch
            {
                return View();
            }
        }

        // GET: Proveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedores.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: Proveedores/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Proveedor proveedor = db.Proveedores.Find(id);
                proveedor.Estatus = false;
                db.Entry(proveedor).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
