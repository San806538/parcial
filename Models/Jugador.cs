using System.ComponentModel.DataAnnotations;

namespace FutbolPeruano.Models{

    public class Jugador
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required]
        public string Posicion { get; set; }
        
        public ICollection<Asignaciones> Asignaciones { get; set; } = new List<Asignaciones>();
    }
}