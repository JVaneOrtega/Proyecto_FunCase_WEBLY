using Proyecto_FunCase_WEBLY.Models;
using System.Web.Mvc;
using System.Linq;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        FunCaseModelContext db = new FunCaseModelContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Imagenes.ToList().Take(10));
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Landing()
        {
            var imagens = db.Imagenes.ToList().Take(10);
            
            return View(imagens);
        }

    }
}
