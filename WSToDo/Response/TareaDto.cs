using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSToDo.Response
{
    public class TareaResponse
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }
        public object Data { get; set; }
    }
}
