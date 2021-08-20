using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using Proyecto_FunCase_WEBLY.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Proyecto_FunCase_WEBLY.Controllers
{
    [Authorize(Roles = "Empleado")]
    public class ComprasController : Controller
    {
        FunCaseModelContext db = new FunCaseModelContext();
        // GET: Compras
        public ActionResult Index()
        {
            return View(db.Compras.ToList());
        }

        // GET: Compras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compras compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }

            return View(compra);
        }

        // GET: Compras/Create
        public ActionResult Create()
        {
            ViewBag.ProveedorID = new SelectList(db.Proveedores, "ProveedorID", "NombreCompleto");
            ViewBag.Modelos = new SelectList(db.Modelos, "ModeloID", "Nombre");
            return View();
        }

        // POST: Compras/Create
        [HttpPost]
        public ActionResult Create(Compras compra, string detalles)
        {
            try
            {
                compra.FechaCompra = DateTime.Now;
                compra.UserId = User.Identity.GetUserId();
                compra.EstatusCompra = "Registrada";

                string ruta = Path.Combine(Server.MapPath("~/Images/Compras/" + compra.ProveedorID));
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
                    compra.FotoTicket = String.Concat("/Images/Compras/", compra.ProveedorID.ToString(), "/", hpf.FileName);
                }

                db.Compras.Add(compra);
                db.SaveChanges();
                var detallesP = JsonConvert.DeserializeObject<List<DetalleCompra>>(detalles);

                foreach(var detalle in detallesP)
                {
                    if(detalle.Cantidad != 0)
                    {
                        detalle.ComprasID = compra.ComprasID;
                        db.DetalleCompras.Add(detalle);
                        
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(compra);
            }
        }

        [HttpGet]
        public JsonResult ConfirmarCompra(int id)
        {
            Compras compra = db.Compras.Find(id);
            if(compra != null)
            {
                List<DetalleCompra> detalles = compra.DetalleCompras.ToList();
                foreach(var detalle in detalles)
                {
                    Producto producto = db.Productos.Find(detalle.ProductoID);
                    producto.Stock += detalle.Cantidad;
                    db.Entry(producto).State = System.Data.Entity.EntityState.Modified;

                    compra.EstatusCompra = "Confirmada";
                    db.Entry(compra).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return Json(new { response = true, mensaje = "Compra confirmada" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { response = false, mensaje = "Compra no encontrada" }, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult ProductosDisponibles(int id)
        {
            return PartialView(db.Productos.Where(p => p.ModeloID == id).ToList());
        }

    }
}
