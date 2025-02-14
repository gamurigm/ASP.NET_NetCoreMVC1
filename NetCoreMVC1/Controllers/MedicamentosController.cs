using Microsoft.AspNetCore.Mvc;

namespace NetCoreMVC1.Controllers
{
    public class MedicamentosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

    
}
