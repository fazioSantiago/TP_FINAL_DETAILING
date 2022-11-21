using System.ComponentModel.DataAnnotations;

namespace TP_FINAL_DETAILING.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre")]
        [DataType(DataType.Text)]
        [MaxLength(30)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese un apellido")]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Ingrese un telefono")]
        [DataType(DataType.Text)]
        [MaxLength(10)]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Ingrese un mail")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(320)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Ingrese una contraseña")]
        [DataType(DataType.Text)]
        [MaxLength(15)]
        public string Contrasenia { get; set; }

    }
}
