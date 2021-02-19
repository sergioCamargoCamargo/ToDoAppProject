using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSToDo.Request
{
    public partial class TareaDtoRequest
    {
        public int IdTarea { get; set; }
        public string TituloTarea { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

    }
}
