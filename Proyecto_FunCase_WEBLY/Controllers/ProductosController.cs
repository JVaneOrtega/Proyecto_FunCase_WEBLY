using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_FunCase_WEBLY.Models;

namespace Proyecto_FunCase_WEBLY.Controllers
{
    public class ProductosController : Controller
    {
        private FunCaseModelContext db = new FunCaseModelContext();

        // GET: Productos
        public ActionResult Index()
        {
            return View(db.Productos.Include(p => p.Material).Include(p => p.Modelo).ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        [Authorize(Roles = "Empleado,Admin")]
        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.MaterialID = new SelectList(db.Materiales, "MaterialID", "Nombre");
            ViewBag.ModeloID = new SelectList(db.Modelos, "ModeloID", "Nombre");
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producto producto)
        {
            string ruta = Path.Combine(Server.MapPath("~/Images/Productos/" + producto.ProductoID));
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
                producto.ImagenFinal = String.Concat("/Images/Productos/", producto.ProductoID.ToString(), "/", hpf.FileName);
            }

            if (ModelState.IsValid)
            {
                db.Productos.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producto);
        }

        [Authorize(Roles = "Empleado,Admin")]
        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Producto producto)
        {
            string ruta = Path.Combine(Server.MapPath("~/Images/Productos/" + producto.ProductoID));
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
                producto.ImagenFinal = String.Concat("/Images/Productos/", producto.ProductoID.ToString(), "/", hpf.FileName);
            }

            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        [Authorize(Roles = "Empleado,Admin")]
        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Productos.Find(id);
            db.Productos.Remove(producto);
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
