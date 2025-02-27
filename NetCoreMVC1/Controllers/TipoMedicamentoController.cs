using Capa_Datos;
using Capa_Entidad;
using Capa_Negocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host;

namespace NetCoreMVC1.Controllers
{
    public class TipoMedicamentoController : Controller
    {
        

        public IActionResult Inicio()
        {
            return View();
        }
        public List<TipoMedicamentoCLS> listarTipoMedicamento()
        {
            TipoMedicamentoBL obj = new TipoMedicamentoBL();
            return  obj.listaMedicamentos();
        }

        public List<TipoMedicamentoCLS> filtrarTipoMedicamento(string nombre)
        {
            TipoMedicamentoBL obj = new TipoMedicamentoBL();
            return obj.filtrarTipoMedicamento(nombre);
        }

        public int GuardarTipoMedicamento(TipoMedicamentoCLS objTipoMedicamentoCLS)
        {
            TipoMedicamentoBL obj = new TipoMedicamentoBL();
            return obj.GuardarTipoMedicamento(objTipoMedicamentoCLS);

        }

        public TipoMedicamentoCLS recuperarTipoMedicamento(int id)
        {
            TipoMedicamentoBL obj = new TipoMedicamentoBL();
            return obj.recuperarTipoMedicamento(id);
        }

        public int Eliminar(int id)
        {
            TipoMedicamentoBL obj = new TipoMedicamentoBL();
            return obj.Eliminar(id);
        }
    }
}
