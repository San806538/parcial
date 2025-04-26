public class Jugador
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Posicion { get; set; }
    
    public ICollection<Asignaciones> Asignaciones { get; set; }
}