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

        public IActionResult SinMenu()
        {
            return View();
        }

        public string Saludo()
        {
            return "Hola amigos";
        }



        public string saludoNombre(string nombre) 
        {
            return "Bienvenido "+ nombre;
        }

        public List<TipoMedicamentoCLS> listarTipoMedicamento()
        {
            TipoMedicamentoBL obj = new TipoMedicamentoBL();
            return  obj.listaMedicamentos();
        }
    }
}
