using Microsoft.AspNetCore.Mvc;
using TP_FINAL_DETAILING.Models;

namespace TP_FINAL_DETAILING.Controllers
{
    public class TurnoController : Controller
    {
        public IActionResult IndexTurno()
        {
            return View();
        }

        public IActionResult CargarTurno()
        {
            ViewBag.NombreServicio = HttpContext.Session.GetString("nombreServicio");
            TempData["idServicio3"] = HttpContext.Session.GetInt32("idServicio");

            return View();
        }

        [HttpPost] //ENVIO DATOS DE LA PAGINA HACIA EL CONTROLADOR 
        public IActionResult CargarTurnoPost(Turno t)
        {
            
            using (DetailingContext context = new())
            {
                             
                context.Turnos.Add(t);//guarda de forma logica al turno
                context.SaveChanges();
                
            }
            return RedirectToAction(nameof(IndexTurno)); //me manda al index de cliente

        }
    }
}

