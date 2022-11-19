using System.ComponentModel.DataAnnotations;

namespace TP_FINAL_DETAILING.Models
{
    public class Turno
    {
        [Key]
        public int IdTurno { get; set; }
        
        [Required]
        public int idCliente { get; set; }
        [Required]
        public int idServicio { get; set; }
        [Required]
        public DateTime Fecha { get; set; } //PREGUNTAR COMO USAR, ver como asignar fecha y hora
        [Required]
        public String Patente { get; set; }
       
 


        
        

    }
}
