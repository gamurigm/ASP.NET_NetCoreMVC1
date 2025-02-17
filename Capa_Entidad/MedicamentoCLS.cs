using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class MedicamentoCLS
    {
        public int IIDMEDICAMENTO { get; set; }  // Primary Key
        public string CODIGO { get; set; }
        public string NOMBREMEDICAMENTO { get; set; }
        public int? IIDLABORATORIO { get; set; }  // Foreign Key
        public int? BHABILITADO { get; set; }
        public int? IIDTIPOMEDICAMENTO { get; set; }  // Foreign Key
        public string USOMEDICAMENTO { get; set; }
        public string CONTENIDO { get; set; }
    }
}
