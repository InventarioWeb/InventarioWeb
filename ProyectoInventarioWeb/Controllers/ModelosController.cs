using ProyectoInventarioWeb.Models;
using ProyectoInventarioWeb.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoInventarioWeb.Controllers
{
    public class ModelosController : Controller
    {
        // GET: Modelos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<ListModelosViewModel> lista = new List<ListModelosViewModel>();
            using (InventarioWebEntities db = new InventarioWebEntities())
            {
                lista =
                    (from lst in db.Modelo
                     orderby lst.id_modelo ascending
                     select new ListModelosViewModel
                     {
                         ID = lst.id_modelo,
                         Nombre = lst.nombre_modelo,
                         Codigo = lst.codigo
                     }).ToList();
            }

            return View(lista);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(ModelosViewModel model)
        {
            try
            {
                using (InventarioWebEntities db = new InventarioWebEntities())
                {
                    var oModelo = new Modelo();
                    oModelo.id_modelo = model.ID;
                    oModelo.nombre_modelo = model.Nombre;
                    db.Modelo.Add(oModelo);
                    db.SaveChanges();
                }
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public ActionResult Edit(int Id)
        {
            ModelosViewModel model = new ModelosViewModel();
            using (InventarioWebEntities db = new InventarioWebEntities())
            {
                var oModelo = db.Modelo.Find(Id);
                model.Nombre = oModelo.nombre_modelo;
                model.ID = oModelo.id_modelo;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(ModelosViewModel model)
        {
            try
            {
                using (InventarioWebEntities db = new InventarioWebEntities())
                {
                    var oModelo = db.Modelo.Find(model.ID);
                    oModelo.nombre_modelo= model.Nombre;
                    db.Entry(oModelo).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            try
            {
                using (InventarioWebEntities db = new InventarioWebEntities())
                {
                    var oModelo = db.Modelo.Find(Id);
                    db.Modelo.Remove(oModelo);
                    db.SaveChanges();
                }
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.InnerException.Message);
            }
        }
    }
}