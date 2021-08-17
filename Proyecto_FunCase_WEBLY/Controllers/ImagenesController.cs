using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Proyecto_FunCase_WEBLY.Models;

namespace Proyecto_FunCase_WEBLY.Controllers
{
    [Authorize(Roles = "Diseñador")]
    public class ImagenesController : Controller
    {
        // GET: Imagenes
        private FunCaseModelContext db = new FunCaseModelContext();
        
        public ActionResult Index()
        {

            try
            {
                string currentUserId = User.Identity.GetUserId();
                var user = db.Users.Find(currentUserId);
                var role = db.Roles.Where(x => x.Name == "Diseñador").FirstOrDefault();

                if (user.Roles.Where(x => x.RoleId == role.Id).FirstOrDefault() != null)
                {
                    return RedirectToAction("Index", "Home");
                }

                var designer = db.Designers.Where(x => x.UserId == currentUserId).FirstOrDefault();

                return View(designer.Imagenes);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        // GET: Imagenes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(db.Imagenes.FirstOrDefault(x => x.ImagenID == id));
        }

        // GET: Imagenes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Imagenes/Create
        [HttpPost]
        public ActionResult Create(Imagen imagen)
        {
            try
            {
                string currentUserId = User.Identity.GetUserId();
                var designerId = db.Designers.Where(x => x.UserId == currentUserId).FirstOrDefault().DesignerID;

                string ruta = Path.Combine(Server.MapPath("~/Images/disenador/" + designerId ));
                
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
                    imagen.Ruta = String.Concat("/Images/disenador/", designerId.ToString(), "/", hpf.FileName);
                }

            
                imagen.DesignerID = designerId;

                db.Imagenes.Add(imagen);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Imagenes/Edit/5
        public ActionResult Edit(int? id)
        {
                     
            return View(db.Imagenes.FirstOrDefault(x => x.ImagenID == id));
        }

        // POST: Imagenes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Imagen imagen)
        {
            try
            {

                string currentUserId = User.Identity.GetUserId();
                var designerId = db.Designers.Where(x => x.UserId == currentUserId).FirstOrDefault().DesignerID;
                string ruta = Path.Combine(Server.MapPath("~/Images/disenador/" + designerId));
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
                    imagen.Ruta = String.Concat("/Images/disenador/", designerId.ToString(), "/", hpf.FileName);
                }

                imagen.DesignerID = designerId;
                db.Entry(imagen).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View(imagen);
            }
            
        }

    }
}
