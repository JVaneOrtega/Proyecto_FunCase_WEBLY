using Proyecto_FunCase_WEBLY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_FunCase_WEBLY.Controllers
{
    public class DesignerController : Controller
    {
        FunCaseModelContext db = new FunCaseModelContext();
        // GET: Designer
        public ActionResult Index()
        {
            return View(db.Designers.ToList());
        }

        // GET: Designer/Details/5
        public ActionResult Details(int id)
        {
            Designer designer = db.Designers.Single(d => d.DesignerID == id);
            return View(designer);
        }

        // GET: Designer/Create
        public ActionResult Create()
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
        }

        // GET: Designer/Edit/5
        public ActionResult Edit(int id)
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
        }

        // GET: Designer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Designer/Delete/5
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
