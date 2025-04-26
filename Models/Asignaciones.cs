public class Asignaciones
{
    public int Id { get; set; }
    
    public int jugadorId { get; set; }
    public Jugador Jugador { get; set; }
    
    public int equipoId { get; set; }
    public Equipos Equipos { get; set; }
}
