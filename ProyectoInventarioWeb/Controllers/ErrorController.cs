using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoInventarioWeb.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult UnauthorizedOperation(string operacion)
        {
            ViewBag.operacion = operacion;
            return View();
        }
    }
}