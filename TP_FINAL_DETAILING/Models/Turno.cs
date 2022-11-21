using System.ComponentModel.DataAnnotations;

namespace TP_FINAL_DETAILING.Models
{
    public class Turno
    {

        [Key]
        public int IdTurno { get; set; }
       
        public int? IdCliente { get; set; }
        
        public int? IdServicio { get; set; }
       
        [Required]
        [DataType(DataType.DateTime)]   
        public DateTime Fecha { get; set; } 
      
        [DataType(DataType.Text)] 
        public string? Patente { get; set; }

        [Required]
        public Boolean Disponible { get; set; }

       
 


        
        

    }
}
