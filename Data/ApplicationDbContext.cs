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

        modelBuilder.Entity<Asignaciones>(entity =>
        {
            entity.Property(e => e.JugadorId).HasColumnName("jugadorId");
            entity.Property(e => e.EquipoId).HasColumnName("equipoId");

            entity.HasIndex(e => new { e.JugadorId, e.EquipoId }).IsUnique();
        });
    }
}