using Microsoft.AspNetCore.Mvc;

namespace NetCoreMVC1.Controllers
{
    public class IngresoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
