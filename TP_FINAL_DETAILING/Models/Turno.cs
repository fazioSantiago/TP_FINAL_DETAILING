using System.ComponentModel.DataAnnotations;

namespace TP_FINAL_DETAILING.Models
{
    public class Turno
    {
        [Key]
        public int IdTurno { get; set; }
        
        [Required]
        public Cliente Cliente { get; set; }
        [Required]
        public Servicio Servicio { get; set; }
        [Required]
        public DateTime Fecha { get; set; } //ver como asignar fecha y hora
        [Required]
        public String Patente { get; set; }
       
        public Boolean EstaAbonado { get; set; } //es necesario? cuando pagas te asigna el turno


        
        

    }
}
