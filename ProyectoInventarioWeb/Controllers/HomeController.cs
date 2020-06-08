using ProyectoInventarioWeb.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoInventarioWeb.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        [AuthorizeUser(idOperacion: 2)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        [AuthorizeUser(idOperacion: 3)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}