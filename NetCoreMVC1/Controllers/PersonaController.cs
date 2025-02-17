using Capa_Entidad;
using Capa_Negocio;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreMVC1.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public List<PersonaCLS> listarPersona()
        {
            PersonaBL obj = new PersonaBL();
            return obj.listaPersonas();
        }

        public List<PersonaCLS> filtrarPersona(string nombre)
        {
            PersonaBL obj = new PersonaBL();
            return obj.filtrarPersona(nombre);
        }
    }
}
