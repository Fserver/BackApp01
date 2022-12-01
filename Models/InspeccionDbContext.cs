using Microsoft.EntityFrameworkCore;

namespace ProyectoFrontBack.Models
{
    public class InspeccionDbContext: DbContext
    {
        public InspeccionDbContext(DbContextOptions<InspeccionDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Inspeccion> Inspeccions { get; set; }
        public virtual DbSet<TipoInspeccion> TipoInspeccions { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
    }
}
