using ProyectoInventarioWeb.Filters;
using ProyectoInventarioWeb.Models;
using ProyectoInventarioWeb.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoInventarioWeb.Controllers
{
    public class CategoriasController : Controller
    {
        // GET: Categorias
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        [AuthorizeUser(idOperacion: 5)]
        public ActionResult Index()
        {
            return View();
        }
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult List()
        {
            List<ListCategoriasViewModel> lista = new List<ListCategoriasViewModel>();
            using (InventarioWebEntities db = new InventarioWebEntities())
            {
                lista =
                    (from lst in db.Categoria
                     orderby lst.id_categoria ascending
                     select new ListCategoriasViewModel
                     {
                         ID = lst.id_categoria,
                         Nombre = lst.nombre_categoria,
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
        public ActionResult Save(CategoriasViewModel model)
        {
            try
            {
                using (InventarioWebEntities db = new InventarioWebEntities())
                {
                    var oCategoria = new Categoria();
                    oCategoria.id_categoria = model.ID;
                    oCategoria.nombre_categoria = model.Nombre;
                    db.Categoria.Add(oCategoria);
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
            CategoriasViewModel model = new CategoriasViewModel();
            using (InventarioWebEntities db = new InventarioWebEntities())
            {
                var oCategoria = db.Categoria.Find(Id);
                model.Nombre = oCategoria.nombre_categoria;
                model.ID = oCategoria.id_categoria;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(CategoriasViewModel model)
        {
            try
            {
                using (InventarioWebEntities db = new InventarioWebEntities())
                {
                    var oCategoria = db.Categoria.Find(model.ID);
                    oCategoria.nombre_categoria = model.Nombre;
                    db.Entry(oCategoria).State = System.Data.Entity.EntityState.Modified;
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
                    var oCategoria = db.Categoria.Find(Id);
                    db.Categoria.Remove(oCategoria);
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