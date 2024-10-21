using Microsoft.AspNetCore.Mvc;

namespace GoturYemek.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Menu()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
