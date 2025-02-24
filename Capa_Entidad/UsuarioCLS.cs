using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public  class UsuarioCLS
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }

        public int IdTipoUsuario { get; set; }
        public string Contra { get; set; }
        public int BHabilitado { get; set; }
    }
}
