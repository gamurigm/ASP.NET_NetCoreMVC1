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

        public List<LaboratorioCLS> filtrarLaboratorio(LaboratorioCLS objLab)
        {
            LaboratorioBL obj = new LaboratorioBL();
            return obj.filtrarLaboratorio(objLab);
        }

        //public int GuardarLaboratorio(LaboratorioCLS objLaboratorioCLS)
        //{
        //    LaboratorioBL obj = new LaboratorioBL();
        //    return obj.GuardarLaboratorio(objLaboratorioCLS);

        //}
    }
}
