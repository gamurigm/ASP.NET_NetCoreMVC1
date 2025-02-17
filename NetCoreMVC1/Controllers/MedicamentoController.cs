using Microsoft.AspNetCore.Mvc;

namespace NetCoreMVC1.Controllers
{
    public class MedicamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
