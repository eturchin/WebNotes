using Microsoft.AspNetCore.Mvc;

namespace WebNotes.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
