using Microsoft.EntityFrameworkCore;
using FutbolPeruano.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Jugador> Jugador { get; set; }
    public DbSet<Equipos> Equipos { get; set; }
    public DbSet<Asignaciones> Asignaciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Asignaciones>()
            .HasIndex(a => new { a.jugadorId, a.equipoId })
            .IsUnique();
    }
}