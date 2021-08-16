using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_FunCase_WEBLY.Models;

namespace Proyecto_FunCase_WEBLY.Controllers
{
    public class ProductoCarritoController : Controller
    {
        private CarritoBDEntities ce = new CarritoBDEntities();

        // GET: ProductoCarrito
        public ActionResult Index()
        {
            return View(ce.Producto.ToList().OrderBy(x=> x.Nombre));
        }
    }
}