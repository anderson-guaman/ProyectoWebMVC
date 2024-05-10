using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System;
namespace AutoPerfecto.Models
{
    public class Compra
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public float PrecioVenta { get; set; }
        [Required]
        public DateTime Fecha { get; set; }

        [ForeignKey("ClienteId")]
        public int? ClienteId { get; set; }
        public Cliente? Cliente { get; set; }


        [ForeignKey("AutoId")]
        public int? AutoId { get; set; }
        public Auto? Auto { get; set; }

       
    }
}
