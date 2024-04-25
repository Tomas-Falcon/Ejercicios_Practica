using Microsoft.EntityFrameworkCore;
using Tarea_Curso_Jorge.Models;

namespace Tarea_Curso_Jorge.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Games> Juegos { get; set; }
    }
}
