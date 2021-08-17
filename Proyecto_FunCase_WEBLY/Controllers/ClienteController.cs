using System.Collections.Generic;
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
        [Authorize(Roles = "Empleado,Admin,Cliente")]
        public ActionResult Index()
        {
            ViewBag.Initial = 0;
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
        }

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
        }*/

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
        [ValidateAntiForgeryToken]
        public ActionResult Index(Cliente cliente)
        {
            try
            {
                Cliente objCliente = db.Clientes.Find(cliente.ClienteID);
                ApplicationUser userCliente = db.Users.Find(cliente.UserId);

                userCliente.Nombre = cliente.User.Nombre;
                userCliente.Apellido1 = cliente.User.Apellido1;
                userCliente.Apellido2 = cliente.User.Apellido2;
                userCliente.Telefono = cliente.User.Telefono;
                userCliente.Email = cliente.User.Email;

                db.Entry(userCliente).State = EntityState.Modified;
                db.SaveChanges();

                objCliente.FechaNacimiento = cliente.FechaNacimiento;
                objCliente.User = userCliente;

                db.Entry(objCliente).State = EntityState.Modified;
                db.SaveChanges();

                return View("Index", db.Clientes.ToList());
            }
            catch
            {
                var clientes = new List<Cliente>();
                clientes.Add(cliente);
                ViewBag.Initial = 1;
                return View("Index" , clientes);
            }
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteID,UserId,Nombre,Apellido1,Apellido2,Telefono,Email,FechaNacimiento")] Cliente cliente)
        {
            try
            {
                Cliente objCliente = db.Clientes.Find(cliente.ClienteID);
                ApplicationUser userCliente = db.Users.Find(cliente.UserId);

                userCliente.Nombre = cliente.User.Nombre;
                userCliente.Apellido1 = cliente.User.Apellido1;
                userCliente.Apellido2 = cliente.User.Apellido2;
                userCliente.Telefono = cliente.User.Telefono;
                userCliente.Email = cliente.User.Email;

                db.Entry(userCliente).State = EntityState.Modified;
                db.SaveChanges();
                
                objCliente.FechaNacimiento = cliente.FechaNacimiento;
                objCliente.User = userCliente;

                db.Entry(objCliente).State = EntityState.Modified;
                db.SaveChanges();

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
