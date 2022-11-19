using Microsoft.AspNetCore.Http;
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
        public IActionResult IniciarSesion()
        {
            
           return View();
        }


        [HttpGet]
        public IActionResult CargarCliente()
        {
           return View();
        }

        [HttpPost] 
        public IActionResult CargarCliente2Post(Cliente c)
        {
            using (DetailingContext context = new())
            {
                context.Clientes.Add(c);
                context.SaveChanges();
               
            }
            TempData["IdCliente"] = c.IdCliente; 

            return RedirectToAction("CargarTurno", "Turno");

        }

        public IActionResult Alerta()
        {
            return View();
        }

        public IActionResult BuscarCliente (String mail, String contrasenia) //lo llaman en CargarCliente
        {
            using (DetailingContext context = new())
            {
                Cliente clienteBuscado = null;
                List<Cliente> clientes = context.Clientes.ToList();
                Cliente? cliente = (from c in clientes where c.Email == mail select c).FirstOrDefault();
                
                if (cliente != null)
                {
                    clienteBuscado = cliente;
                    TempData["IdCliente"] = clienteBuscado.IdCliente;
                    string psw = clienteBuscado.Contrasenia;
                    if (psw.Equals(contrasenia))
                    {
                      return RedirectToAction("CargarTurno", "Turno");
                    } else
                    {
                      
                      return RedirectToAction("Alerta", "Cliente");
                    }

                } else //No encontró al cliente
                {
                    return RedirectToAction("Alerta", "Cliente");
                }

            }
            
        }

        [HttpGet]
        public IActionResult ValidarDatos(Cliente clienteBuscado) 
        {
            ViewBag.NombreServicio = HttpContext.Session.GetString("nombre");
            TempData["IdCliente"] = clienteBuscado.IdCliente; //se va a usar por primera vez en TurnoControler
            //te tira todos los datos ya completos para dar el ok;
            return View(clienteBuscado); //le estoy pasando por parametro al cliente?
        }

        public IActionResult RedirigirCl()
        {
            return RedirectToAction("CargarTurno", "Turno");
        }

       
    }
}

//while (i < clientes.Count)
//{
//    if (clientes[i].Email.Equals(mail)) {
//        clienteBuscado = clientes[i];
//    } else
//    {
//        i++;
//    }

//}