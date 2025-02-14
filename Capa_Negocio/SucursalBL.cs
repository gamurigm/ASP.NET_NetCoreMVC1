using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class SucursalBL
    {

        public List<SucursalCLS> listaSucursales()
        {
            SucursalDAL obj = new SucursalDAL();
            return obj.listarSucursal();

        }
    }
}
