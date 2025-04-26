public class Equipos
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public ICollection<Asignaciones> Asignaciones { get; set; }
}
