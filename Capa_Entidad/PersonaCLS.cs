using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class PersonaCLS
    {
        public int iidPersona { get; set; }
        public string nombre { get; set; }
        public string apPaterno { get; set; }
        public string apMaterno { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public int iidsexo { get; set; }
        public int bhabilitado { get; set; }
        public string telefono { get; set; }
        public int bempleado { get; set; }
        public int iidSucursal{ get; set; }
        
    }
}
