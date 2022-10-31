using Microsoft.AspNetCore.Mvc;
using TP_FINAL_DETAILING.Models;

namespace TP_FINAL_DETAILING.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {


            HttpContext.Session.SetInt32("Valor", 2);
            int? miValorInt = HttpContext.Session.GetInt32("Valor");

            HttpContext.Session.SetString("ValorString", "Juan");
            string? miValor = HttpContext.Session.GetString("ValorString");

            Cliente cli = new Cliente();
            cli.Nombre = "Prueba";
            cli.Apellido = "PruebaAp";
                        
            TempData["MiValorTemporal"] = cli; //Guarda cualquier tipo de objeto y lo puedo pasar a cualquier lado
            return View();
        }

        [HttpPost]
        public IActionResult Redirigir()
        {
            //return RedirectToAction(nameof(ClienteController.CargarCliente));
            return RedirectToAction("CargarCliente", "Cliente");
        }

        public IActionResult Prueba()
        {
            return View();
        }
        //ARMAR LANDING
    }
}
