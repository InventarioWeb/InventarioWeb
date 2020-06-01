using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoInventarioWeb.Models.ViewModel
{
    public class ListProductoViewModel
    {
        public int ID { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string SKU { get; set; }
        public decimal? Precio { get; set; }
        public int? Existencia { get; set; }
        public int? idCategoria { get; set; }
        public int? idMarca { get; set; }
        public int? idModelo { get; set; }
        public int? Año { get; set; }
        public int? idProveedor { get; set; }
        public string Descripcion { get; set; }

    }
}