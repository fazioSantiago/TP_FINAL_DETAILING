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
        public IActionResult CargarCliente()
        {
            int? id = (int?)TempData["idServicio"];
            string? nombre;
            
            using (DetailingContext context = new())
            {
                var nomServicio = context.Servicios.Find(id);
                nombre = nomServicio?.NombreServicio;
                 //esto lo muestro en la vista
                
            }

            TempData["nombreServicio"] = nombre;
            HttpContext.Session.SetString("nombre", nombre);
            return View();
        }


        //[HttpPost] //ENVIO DATOS DE LA PAGINA HACIA EL CONTROLADOR 
        //public IActionResult CargarClientePost(Cliente c)
        //{
        //    using (DetailingContext context = new())
        //    {
        //        context.Clientes.Add(c);//guarda de forma logica al cliente
        //        context.SaveChanges();
        //        TempData["CLienteTurno"] = c;
        //    }
        //    return RedirectToAction(nameof(Index)); //me manda al index de cliente
             
        //}

        [HttpGet]
        public IActionResult CargarCliente2()
        {
            //int? id = (int?)TempData["idServicio"];
            //string nombre;


            //using (DetailingContext context = new())
            //{
            //    var nomServicio = context.Servicios.Find(id);
            //    nombre = nomServicio.NombreServicio;
            //    ViewBag.nombreServicio = nombre;//esto lo muestro en la vista

            //}

            string? mail = TempData["mailCli"].ToString();
            ViewBag.Mail = mail;
            ViewBag.NombreServicio = HttpContext.Session.GetString("nombre");

            return View();
        }

        [HttpPost] //ENVIO DATOS DE LA PAGINA HACIA EL CONTROLADOR 
        public IActionResult CargarCliente2Post(Cliente c)
        {
            using (DetailingContext context = new())
            {
                context.Clientes.Add(c);//guarda de forma logica al cliente
                context.SaveChanges();
                //TempData["CLienteTurno"] = (Cliente) c;
            }
            TempData["IdCliente"] = c.IdCliente; //se va a usar por primera vez en TurnoControler

            return RedirectToAction("CargarTurno", "Turno"); //me manda al index de cliente

        }



        public IActionResult BuscarCliente (String mail)
        {
            using (DetailingContext context = new())
            {
                //var clienteBuscado = context.Clientes.Find(mail);
                int i = 0;
                Cliente clienteBuscado = null;
                List<Cliente> clientes = context.Clientes.ToList();
                Cliente? cliente = (from c in clientes where c.Email == mail select c).FirstOrDefault();

                if (cliente != null)
                {
                    clienteBuscado = cliente;   
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

                if (clienteBuscado == null)
                {
                    TempData["mailCli"] = mail;
                  
                    return RedirectToAction(nameof(CargarCliente2)); //deberia pasar el mail por parametro
                } else
                {
                    //TempData["cEncontrado"] = clienteBuscado;
                    return RedirectToAction(nameof(ValidarDatos), clienteBuscado); //que mande a un revisar datos
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
