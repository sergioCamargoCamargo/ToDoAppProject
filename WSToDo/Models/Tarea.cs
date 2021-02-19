using System;
using System.Collections.Generic;

#nullable disable

namespace WSToDo.Models
{
    public partial class Tarea
    {
        public int IdTarea { get; set; }
        public string TituloTarea { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
