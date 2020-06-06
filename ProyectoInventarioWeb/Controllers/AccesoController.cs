using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoInventarioWeb.Models;

namespace ProyectoInventarioWeb.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Login()
        {
            return View();
        }
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult LogOut()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Login", "Acceso");
        }

        [HttpPost]
        public ActionResult Login(string email, string pass)
        {
            try
            {
                using (InventarioWebEntities db = new InventarioWebEntities())
                {
                    var oUser = (from d in db.Usuario
                                 where d.correo == email && d.contraseña == pass
                                 select d).FirstOrDefault();
                    if (oUser == null || (oUser.correo).ToString() != email || (oUser.contraseña).ToString() != pass)
                    {
                        ViewBag.Error = "Usuario o contraseña inválidos";
                        return View();

                    }
                    else
                    {
                        Session["Usuario"] = oUser;
                    }

                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                ViewBag.Error = "Ocurrió un error al conectarse a la Base de Datos, intente de nuevo";
                return View();
            }
        }
    }
}