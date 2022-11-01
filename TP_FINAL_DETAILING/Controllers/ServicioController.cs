using Microsoft.AspNetCore.Mvc;

namespace TP_FINAL_DETAILING.Controllers
{
    public class ServicioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult InstanciarServicio()
        {
            
            return RedirectToAction("CargarCliente", "Cliente");
        }
    }
}
