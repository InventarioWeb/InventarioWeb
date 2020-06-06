using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoInventarioWeb.Models;

namespace ProyectoInventarioWeb.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Registrar()
        {
            return View();
        }

        public ActionResult Enviar(string name, string email, string password, string cel)
        {
            try
            {
                using (InventarioWebEntities db = new InventarioWebEntities())
                {
                    Usuario nuevo = new Usuario
                    {
                        nombre_usuario = name,
                        correo = email,
                        contraseña = password,
                        telefono = cel,
                        id_rol = 2,
                        Fecha = DateTime.Now,
                        codigo = "User"
                    };

                    db.Usuario.Add(nuevo);

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {

                    }

                    var lst = from d in db.Usuario
                              where d.nombre_usuario == name && d.contraseña == password
                              select d;

                    if (lst.Count() > 0)
                    {
                        return Content("1");
                    }
                    else
                    {
                        return Content("No ingresado :'(");
                    }
                }


            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error :( " + ex.Message);
            }
        }
    }
}