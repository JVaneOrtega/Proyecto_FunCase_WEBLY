using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_FunCase_WEBLY.Models;

namespace Proyecto_FunCase_WEBLY.Controllers
{
    public class VentasController : Controller
    {
        private CarritoBDEntities ce = new CarritoBDEntities();

        // GET: Ventas
        public ActionResult Index()
        {
            var ventas = ce.Venta.ToList();

            return View(ventas);
        }

        public ActionResult DetalleVenta(int id)
        {
            var venta = ce.Venta.Find(id);

            return View(venta);
        }
    }
}