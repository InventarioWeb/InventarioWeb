using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProyectoInventarioWeb.Models.ViewModel
{
    public class CategoriasViewModel
    {
        public int ID { get; set; }
        [DisplayName("Nombre de Categoria")]
        public string Nombre { get; set; }
        [DisplayName("Codigo")]
        public string Codigo { get; set; }
    }
}