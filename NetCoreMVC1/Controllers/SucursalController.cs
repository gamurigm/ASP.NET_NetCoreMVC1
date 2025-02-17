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

        public List<SucursalCLS> filtrarSucursal(string nombre)
        {
            SucursalBL obj = new SucursalBL();
            return obj.filtrarSucursal(nombre);
        }

    }
}
