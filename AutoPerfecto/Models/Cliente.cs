using System.ComponentModel.DataAnnotations;

namespace AutoPerfecto.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Cedula { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Telefono {  get; set; }
        [Required]
        public string Direccion {  get; set; }
    }
}
