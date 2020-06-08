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
    public class ProductosController : Controller
    {
        // GET: Productos
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        [AuthorizeUser(idOperacion: 4)]
        public ActionResult Index()
        {
            return View();
        }
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult List()
        {
            List<ListProductoViewModel> lst = new List<ListProductoViewModel>();
            using (InventarioWebEntities db = new InventarioWebEntities())
            {
                lst =
                    (from lista in db.Producto
                     orderby lista.id_producto ascending
                     select new ListProductoViewModel
                     {
                         ID = lista.id_producto,
                         Codigo = lista.codigo,
                         Nombre = lista.nombre_producto,
                         SKU = lista.SKU,
                         Precio = lista.precio_unitario,
                         Existencia = lista.existencia,
                         idCategoria = lista.id_categoria,
                         idMarca = lista.id_marca,
                         idModelo = lista.id_modelo,
                         Año = lista.año,
                         idProveedor = lista.id_proveedor,
                         Descripcion = lista.descripcion

                     }).ToList();
            }

            return View(lst);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(ProductosViewModel model)
        {
            try
            {
                using (InventarioWebEntities db = new InventarioWebEntities())
                {
                    var oProducto = new Producto();
                    oProducto.id_producto = model.ID;
                    oProducto.nombre_producto = model.Nombre;
                    oProducto.SKU = model.SKU;
                    oProducto.precio_unitario = model.Precio;
                    oProducto.existencia = model.Existencia;
                    oProducto.id_categoria = model.idCategoria;
                    oProducto.id_marca = model.idMarca;
                    oProducto.id_modelo = model.idModelo;
                    oProducto.año = model.Año;
                    oProducto.id_proveedor = model.idProveedor;
                    oProducto.descripcion = model.Descripcion;
                    oProducto.FechaRegistro = model.Fecha;
                    db.Producto.Add(oProducto);
                    db.SaveChanges();
                }
                return Content("1");
            }
            catch 
            {
                return Content("Es Necesario llenar todos los campos");
            }
        }

        public ActionResult Edit(int Id)
        {
            ProductosViewModel model = new ProductosViewModel();
            using (InventarioWebEntities db = new InventarioWebEntities())
            {
                var oProducto = db.Producto.Find(Id);
                model.Nombre = oProducto.nombre_producto;
                model.SKU = oProducto.SKU;
                model.Precio = oProducto.precio_unitario;
                model.Existencia = oProducto.existencia;
                model.idCategoria = oProducto.id_categoria;
                model.idMarca = oProducto.id_marca;
                model.idModelo = oProducto.id_modelo;
                model.Año = oProducto.año;
                model.idProveedor = oProducto.id_proveedor;
                model.Descripcion = oProducto.descripcion;
                model.Fecha = oProducto.FechaRegistro;
                model.ID = oProducto.id_producto;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(ProductosViewModel model)
        {
            try
            {
                using (InventarioWebEntities db = new InventarioWebEntities())
                {
                    var oProducto = db.Producto.Find(model.ID);
                    oProducto.nombre_producto = model.Nombre;
                    oProducto.SKU = model.SKU;
                    oProducto.precio_unitario = model.Precio;
                    oProducto.existencia = model.Existencia;
                    oProducto.id_categoria = model.idCategoria;
                    oProducto.id_marca = model.idMarca;
                    oProducto.id_modelo = model.idModelo;
                    oProducto.año = model.Año;
                    oProducto.id_proveedor = model.idProveedor;
                    oProducto.descripcion = model.Descripcion;
                    db.Entry(oProducto).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return Content("1");
            }
            catch
            {
                return Content("Es Necesario llenar todos los campos");
            }
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            try
            {
                using (InventarioWebEntities db = new InventarioWebEntities())
                {
                    var oProducto = db.Producto.Find(Id);
                    db.Producto.Remove(oProducto);
                    db.SaveChanges();
                }
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.InnerException.Message);
            }
        }

        //InventarioWebEntities db = new InventarioWebEntities();
        //public ActionResult Buscador(string Nombre)
        //{
        //    var busqueda = from s in db.Producto select s;

        //    if (!String.IsNullOrEmpty(Nombre))
        //    {
        //        busqueda = busqueda.Where(s => s.nombre_producto.Contains(Nombre));
        //                               //|| s.codigo.Contains(Nombre));
        //    }
        //    return View(busqueda);
        //}


    }
}