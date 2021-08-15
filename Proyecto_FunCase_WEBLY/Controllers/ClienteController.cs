using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using IdentitySample.Models;
using Proyecto_FunCase_WEBLY.Models;

namespace Proyecto_FunCase_WEBLY.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        public FunCaseModelContext db = new FunCaseModelContext();

        // GET: Cliente
        public ActionResult Index()
        {
            return View(db.Clientes.ToList()); ;
        }

        // GET: Cliente/Details/5
        [Authorize(Roles = "Empleado,Admin")]
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if(cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [Authorize(Roles = "Cliente")]
        public ActionResult Profile(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Profile", cliente);
        }

        // GET: Cliente/Create
        /*public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                ApplicationUser userCliente = new ApplicationUser {  };
                Cliente objCliente = new Cliente { };

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/

        // GET: Cliente/Edit/5
        [Authorize(Roles = "Admin,Empleado")]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cliente cliente = db.Clientes.Find(id);

            return View(cliente);
        }

        [Authorize(Roles = "Cliente")]
        public ActionResult EditProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cliente cliente = db.Clientes.Find(id);

            return PartialView("_EditProfile", cliente);
        }

        // POST: Cliente/Edit/5
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
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if(cliente == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Cliente cliente = db.Clientes.Find(id);
                cliente.Estatus = false;
                db.Entry(cliente).State = EntityState.Modified;
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
