using Microsoft.AspNetCore.Mvc;
using TP_FINAL_DETAILING.Models;

namespace TP_FINAL_DETAILING.Controllers
{
    public class ClienteController : Controller
    
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet] //TRABAJA CON GET PORQUE ESTÁ CARGANDO LA PAGINA
        public IActionResult CargarCliente()
        {
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

            //para que nos mande a una View de otro controlador, le pongo el controlador y el nombre de la vista.
            //Como le paso el objeto cliente?
        }
    }
}
