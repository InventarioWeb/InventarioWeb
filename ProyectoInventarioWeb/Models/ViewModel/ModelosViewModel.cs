using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProyectoInventarioWeb.Models.ViewModel
{
    public class ModelosViewModel
    {
        public int ID { get; set; }
        [DisplayName("Nombre de Modelo")]
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }
}