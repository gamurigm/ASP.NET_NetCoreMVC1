using Capa_Entidad;
using Capa_Negocio;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreMVC1.Controllers
{
    public class SucursalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<SucursalCLS> listarSucursal()
        {
            SucursalBL obj = new SucursalBL();
            return obj.listaSucursales();
        }   

        public List<SucursalCLS> filtrarSucursal(SucursalCLS objSucursal)
        {
            SucursalBL obj = new SucursalBL();
            return obj.filtrarSucursal(objSucursal);
        }

        public int GuardarSucursal(SucursalCLS objSucursalCLS)
        {
            SucursalBL obj = new SucursalBL();
            return obj.GuardarSucursal(objSucursalCLS);

        }

        public SucursalCLS recuperarSucursal(int id)
        {
            SucursalBL obj = new SucursalBL();
            return obj.recuperarSucursal(id);
        }

        public int Eliminar(int id)
        {
            SucursalBL obj = new SucursalBL();
            return obj.Eliminar(id);
        }

    }
}
