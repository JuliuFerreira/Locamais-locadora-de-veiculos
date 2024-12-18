using Microsoft.AspNetCore.Mvc;

namespace LocaMais.Controllers
{
    public class AluguelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
