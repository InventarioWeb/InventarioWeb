using ProyectoInventarioWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoInventarioWeb.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeUser : AuthorizeAttribute
    {
        private Usuario oUsuario;
        private InventarioWebEntities db = new InventarioWebEntities();
        private int idOperacion;

        public AuthorizeUser(int idOperacion = 0)
        {
            this.idOperacion = idOperacion;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            String nombreOperacion = "";

            try
            {
                oUsuario = (Usuario)HttpContext.Current.Session["Usuario"];
                var lstMisOperaciones = from m in db.Rol_Operacion
                                        where m.id_rol == oUsuario.id_rol
                                        && m.id_Operacion == idOperacion
                                        select m;
                HttpContext.Current.Session["RolUsuario"] = oUsuario.id_rol;
                if (lstMisOperaciones.ToList().Count() == 0)
                {
                    nombreOperacion = getNombreDeOperacion(idOperacion);
                    filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operacion=" + nombreOperacion);
                }
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Error/SinRed?operacion=" + nombreOperacion);
            }
        }

        public string getNombreDeOperacion(int idOperacion)
        {
            var ope = from op in db.Operaciones
                      where op.id_Operacion == idOperacion
                      select op.nombre_Operacion;
            string nombreOperacion;
            try
            {
                nombreOperacion = ope.First();
            }
            catch (Exception)
            {
                nombreOperacion = "";
            }
            return nombreOperacion;
        }
    }
}