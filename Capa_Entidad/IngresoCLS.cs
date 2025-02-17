using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class IngresoCLS
    {
        public int IIDINGRESO { get; set; }  // Primary Key
        public int? IIDMEDICAMENTO { get; set; }  // Foreign Key
        public int? IIDLABORATORIO { get; set; }  // Foreign Key
        public DateTime? FECHACOMPRA { get; set; }
        public int? CANTIDAD { get; set; }
        public DateTime? FECHAVENCIMIENTO { get; set; }
        public decimal? PRECIOCOMPRA { get; set; }
        public int? BHABILITADO { get; set; }
        public DateTime? DFECHAVENCIMIENTO { get; set; }
        public int? IIDMARCA { get; set; }  // Foreign Key
        public decimal? PRECIOVENTA { get; set; }
    }
}
