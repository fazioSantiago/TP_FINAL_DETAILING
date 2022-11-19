using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TP_FINAL_DETAILING.Models;

namespace TP_FINAL_DETAILING.Controllers
{
    public class HomeController : Controller
    {
        
        [HttpGet]
        public IActionResult Index()
        {
            List <Servicio> servicios = null;
            
            using (DetailingContext context = new())
            {
                servicios = context.Servicios.ToList();
            }

            return View(servicios);
        }

        [HttpGet]
        public IActionResult Redirigir(int id)
        {
            string? nombre;

            using (DetailingContext context = new())
            {
                var nomServicio = context.Servicios.Find(id);
                nombre = nomServicio?.NombreServicio;
               
            }

            HttpContext.Session.SetString("nombreServicio", nombre);
            HttpContext.Session.SetInt32("idServicio", (int)id);

            return RedirectToAction("IniciarSesion", "Cliente");
        }


        public IActionResult detalleFacturacion()
        {
            List<Turno> turnos = null;
            List<Servicio> servicios = null;
            List<int> acumuladores = new List<int>();   
            
            using (DetailingContext context = new())
            {
                turnos = context.Turnos.ToList();
                ViewBag.Servicios = context.Servicios.ToList();
                int acumulador1 = 0;
                int acumulador2 = 0;
                int acumulador3 = 0;
              

                foreach (Turno t in turnos)
                {
                    int Id = t.idServicio;

                    if (Id == 1)
                    {
                        acumulador1++;
                    }
                    else if (Id == 1)
                    {
                        acumulador2++;
                    }
                    else
                    {
                       acumulador3++;
                    }
                }
                acumuladores.Add(acumulador1);
                acumuladores.Add(acumulador2);
                acumuladores.Add(acumulador3);

            }
            return View(acumuladores);
        }
 

    }
}
