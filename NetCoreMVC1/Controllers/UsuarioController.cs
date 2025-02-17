using Microsoft.AspNetCore.Mvc;

namespace NetCoreMVC1.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult IndexUsuario()
        {
            return View();
        }
    }
}
