using Microsoft.EntityFrameworkCore;
using examenweb2parcial.Models;

namespace examenweb2parcial.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Miembro> Miembros { get; set; }
        public DbSet<Prioridad> Prioridades { get; set; }
    }
}