using Microsoft.AspNetCore.Mvc;
using TP_FINAL_DETAILING.Models;

namespace TP_FINAL_DETAILING.Controllers
{
    public class TurnoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CargarTurno()
        {
            return View();
        }

        [HttpPost] //ENVIO DATOS DE LA PAGINA HACIA EL CONTROLADOR 
        public IActionResult CargarTurnoPost(Turno t)
        {
            Cliente cli = (Cliente) TempData["MiValorTemporal"];

            using (DetailingContext context = new())
            {
                context.Turnos.Add(t);//guarda de forma logica al cliente
                context.SaveChanges();
                
            }
            return RedirectToAction(nameof(Index)); //me manda al index de cliente

            //para que nos mande a una View de otro controlador, le pongo el controlador y el nombre de la vista.
            //Como le paso el objeto cliente?
        }
    }
}

