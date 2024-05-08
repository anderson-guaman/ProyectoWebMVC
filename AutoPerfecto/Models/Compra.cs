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

        [ForeignKey("IdCliente")]
        public int? IdCliente { get; set; }


        [ForeignKey("IdAuto")]
        public int? IdAuto { get; set; }

        public Compra() {
            Fecha = DateTime.Now;
        }
    }
}
