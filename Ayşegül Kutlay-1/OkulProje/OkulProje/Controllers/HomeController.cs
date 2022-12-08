using Microsoft.AspNetCore.Mvc;

namespace OkulProje.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
