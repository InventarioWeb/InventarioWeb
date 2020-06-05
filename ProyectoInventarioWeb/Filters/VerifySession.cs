using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoInventarioWeb.Controllers;
using ProyectoInventarioWeb.Models;

namespace ProyectoInventarioWeb.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        private Usuario oUsuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                oUsuario = (Usuario)HttpContext.Current.Session["Usuario"];
                if (oUsuario == null)
                {
                    if (filterContext.Controller is AccesoController == false)
                    {
                        if (filterContext.Controller is AccountController == true)
                        {

                        }
                        else
                        {
                            filterContext.HttpContext.Response.Redirect("~/Acceso/Login");
                        }

                    }

                }
                else
                {
                    if (filterContext.Controller is AccesoController == true || filterContext.Controller is AccountController == true)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Home/Index");
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}