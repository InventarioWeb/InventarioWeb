//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoInventarioWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        public int id_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }
        public string telefono { get; set; }
        public int id_rol { get; set; }
        public System.DateTime Fecha { get; set; }
        public string codigo { get; set; }
    
        public virtual Rol Rol { get; set; }
    }
}