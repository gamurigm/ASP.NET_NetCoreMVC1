using Capa_Datos;
using Capa_Entidad;
using Capa_Negocio;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreMVC1.Controllers
{
    public class LaboratorioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<LaboratorioCLS> listarLaboratorio()
        {
            LaboratorioBL obj = new LaboratorioBL();
            return obj.listaLaboratorios();
        }

        public List<LaboratorioCLS> filtrarLaboratoriol(string nombre)
        {
            LaboratorioBL obj = new LaboratorioBL();
            return obj.filtrarLaboratorio(nombre);
        }
    }
}
