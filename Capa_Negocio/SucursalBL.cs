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

        public List<SucursalCLS> filtrarSucursal(SucursalCLS objSucursal)
        {
            SucursalDAL obj = new SucursalDAL();
            return obj.filtrarSucursal(objSucursal);

        }

        public int GuardarSucursal(SucursalCLS oSucursalCLS)
        {
            SucursalDAL obj = new SucursalDAL();
            return obj.GuardarSucursal(oSucursalCLS);

        }

        public SucursalCLS recuperarSucursal(int id)
        {
            SucursalDAL obj = new SucursalDAL();
            return obj.recuperarSucursal(id);
        }

        public int Eliminar(int id)
        {
            SucursalDAL obj = new SucursalDAL();
            return obj.Eliminar(id);
        }

    }
}
