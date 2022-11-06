using Microsoft.AspNetCore.Mvc;
using TP_FINAL_DETAILING.Models;

namespace TP_FINAL_DETAILING.Controllers
{
    public class ClienteController : Controller
    
    {
        public IActionResult Index()
        {
            //hola
            return View();
        }

        [HttpGet] //TRABAJA CON GET PORQUE ESTÁ CARGANDO LA PAGINA
        public IActionResult CargarCliente()
        {
            int? id = (int?)TempData["idServicio"];
                                    
            using (DetailingContext context = new())
            {
                var nomServicio = context.Servicios.Find(id);
                string nombre = nomServicio.NombreServicio;
                ViewBag.nombreServicio = nombre; //esto lo muestro en la vista
                
            }

            return View();
        }



        [HttpPost] //ENVIO DATOS DE LA PAGINA HACIA EL CONTROLADOR 
        public IActionResult CargarClientePost(Cliente c)
        {
            using (DetailingContext context = new())
            {
                context.Clientes.Add(c);//guarda de forma logica al cliente
                context.SaveChanges();
                TempData["CLienteTurno"] = c;
            }
            return RedirectToAction(nameof(Index)); //me manda al index de cliente

        }
    }
}
