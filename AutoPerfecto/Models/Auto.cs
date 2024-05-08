﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoPerfecto.Models
{
    public class Auto
    {
        [Key]
        public int Id { get; set; }

        [DefaultValue(false)]
        public bool? Vendido { get; set; }
        [Required]
        public string Marca { get; set;}
        [Required]
        public string Modelo { get; set;}
        [Required]
        public int AnioFabricacion { get; set;}
        [Required]
        public string Color { get; set;}
        [Required]
        public int KmActual { get; set;}
        [Required]
        public string TipoAuto { get; set;}
        [Required]
        public string Transmision { get; set;}
        [Required]
        public string TipoCombustible { get; set;}
        [Required]
        public float Cilindraje { get; set;}
        [Required]
        public int Potencia {  get; set;}
    }
}
