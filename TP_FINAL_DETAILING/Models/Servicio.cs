using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TP_FINAL_DETAILING.Models
{
    public class Servicio
    {
        [Key]
        public int IdServicio { get; set; }
        [Required]
        [MaxLength(100)]
        public string NombreServicio { get; set; }
        [MaxLength(500)]
        public string DescripcionServicio { get; set; }
        [Required]
        public double Precio { get; set; }        
    }
}
