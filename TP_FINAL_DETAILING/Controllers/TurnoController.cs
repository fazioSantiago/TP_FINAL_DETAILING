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

        [HttpGet]
        public IActionResult CargarTurno(int id)
        {
            ViewBag.NombreServicio = HttpContext.Session.GetString("nombreServicio");
            TempData["idServicio3"] = HttpContext.Session.GetInt32("idServicio");
            Turno? turnoBuscado = null; 

            using (DetailingContext context = new())
            {
                turnoBuscado = context.Turnos.Find(id);
            }
            
                
                return View(turnoBuscado);
        }

        [HttpPost] //ENVIO DATOS DE LA PAGINA HACIA EL CONTROLADOR 
        public IActionResult CargarTurnoPost(Turno t)
        {
            
            using (DetailingContext context = new())
            {
                t.Disponible = false;
                context.Turnos.Update(t);
                context.SaveChanges();
                
            }
            return RedirectToAction("IndexTurno"); 

        }

        public IActionResult Reservar()
        {
            List<Turno> turnos = null;

            using (DetailingContext context = new())
            {
                turnos = context.Turnos.ToList();

            }

            return View(turnos);
        }
    }
}

