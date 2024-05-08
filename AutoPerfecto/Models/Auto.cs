namespace AutoPerfecto.Models
{
    public class Auto
    {
        public int Id { get; set; }
        public int Estado { get; set; }
        public string Marca { get; set;}
        public string Modelo { get; set;}
        public int AnioFabricacion { get; set;}
        public string Color { get; set;}
        public int KmActual { get; set;}
        public string TipoAuto { get; set;}
        public string Transmision { get; set;}
        public string TipoCombustible { get; set;}
        public float Cilindraje { get; set;}
        public int Potencia {  get; set;}
    }
}
