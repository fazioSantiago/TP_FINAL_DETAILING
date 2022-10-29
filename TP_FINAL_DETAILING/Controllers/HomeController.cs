using Microsoft.AspNetCore.Mvc;

namespace TP_FINAL_DETAILING.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
