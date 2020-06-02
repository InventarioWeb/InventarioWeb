using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProyectoInventarioWeb.Models.ViewModel
{
    public class ProductosViewModel
    {
        public int ID { get; set; }
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        [DisplayName("SKU")]
        public string SKU { get; set; }
        [DisplayName("Precio")]
        public decimal? Precio { get; set; }
        [DisplayName("Cantidad")]
        public int? Existencia { get; set; }
        [DisplayName("Categoria")]
        public int? idCategoria { get; set; }
        [DisplayName("Marca")]
        public int? idMarca { get; set; }
        [DisplayName("Modelo")]
        public int? idModelo { get; set; }
        [DisplayName("Año")]
        public int? Año { get; set; }
        [DisplayName("Proveedor")]
        public int? idProveedor { get; set; }
        [DisplayName("Descripcion")]
        public string Descripcion { get; set; }
        [DisplayName("Fecha")]
        public DateTime? Fecha { get; set; }
    }
}