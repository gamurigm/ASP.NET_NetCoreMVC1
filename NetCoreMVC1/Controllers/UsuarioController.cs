using Capa_Entidad;
using Capa_Negocio;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreMVC1.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult IndexUsuario()
        {
            return View();
        }
        public List<UsuarioCLS> listarUsuario()
        {
            UsuarioBL obj = new UsuarioBL();
            return obj.listaUsuarios();
        }

        public List<UsuarioCLS> filtrarUsuario(string nombre)
        {
            UsuarioBL obj = new UsuarioBL();
            return obj.filtrarUsuario(nombre);
        }
    }
}
