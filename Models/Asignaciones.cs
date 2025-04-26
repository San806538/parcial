using FutbolPeruano.Models;
namespace FutbolPeruano.Models{

    public class Asignaciones
    {
        public int Id { get; set; }
        
        public int JugadorId { get; set; }
        public Jugador? Jugador { get; set; }
        
        public int EquipoId { get; set; }
        public Equipos? Equipo { get; set; }
    }
}