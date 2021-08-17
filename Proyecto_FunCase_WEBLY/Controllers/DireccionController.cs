using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Proyecto_FunCase_WEBLY.Models;

namespace Proyecto_FunCase_WEBLY.Controllers
{
    [Authorize]
    public class DireccionController : Controller
    {
        // GET: Direccion
        private FunCaseModelContext db = new FunCaseModelContext();
        public ActionResult Index()
        {
            try
            {
                string currentUserId = User.Identity.GetUserId();
                var user = db.Users.Find(currentUserId);
                var role = db.Roles.Where(x => x.Name == "Cliente").FirstOrDefault();

                if (user.Roles.Where(x => x.RoleId == role.Id).FirstOrDefault() != null)
                {
                    return RedirectToAction("Index", "Home");
                }

                var client = db.Clientes.Where(x => x.UserId == currentUserId).FirstOrDefault();

                return View(client.Direcciones);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
           
        }

        // GET: Direccion/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Direcciones.FirstOrDefault(x => x.DireccionID == id));
        }

        // GET: Direccion/Create
        public ActionResult Create()
        {
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre");
            return View();
        }

        // POST: Direccion/Create
        [HttpPost]
        public ActionResult Create(Direccion direccion)
        {
            try
            {
                string currentUserId = User.Identity.GetUserId();
                
                var client = db.Clientes.Where(x => x.UserId == currentUserId).FirstOrDefault();
                direccion.ClienteID = client.ClienteID;
                
                db.Direcciones.Add(direccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Direccion/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Nombre");
            return View(db.Direcciones.FirstOrDefault(x => x.DireccionID == id));
        }

        // POST: Direccion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Direccion direccion)
        {
            try
            {
                // TODO: Add update logic here
                var dir = db.Direcciones.FirstOrDefault(x => x.DireccionID == id);
                dir.CodigoPostal = direccion.CodigoPostal;
                dir.Calle = direccion.Calle;
                dir.Colonia = direccion.Colonia;
                dir.EstadoID = direccion.EstadoID;
                dir.Estatus = direccion.Estatus;
                dir.NumeroExt = direccion.NumeroExt;
                dir.NumeroInt = direccion.NumeroInt;
                db.SaveChanges();
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Direccion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Direccion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
