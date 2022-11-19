using System.ComponentModel.DataAnnotations;

namespace TP_FINAL_DETAILING.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; }
        [Required]
        [MaxLength(10)]
        public string Telefono { get; set; }

        [Required]
        [MaxLength(320)]
        public string Email { get; set; }


        [Required]
        public string Contrasenia { get; set; }

    }
}
