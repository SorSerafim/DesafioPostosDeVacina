using DesafioPostosDeVacina.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioPostosDeVacina.Infra.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Posto> Postos { get; set; }
        public DbSet<Vacina> Vacinas { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Posto>()
                .HasIndex(p => p.Nome)
                .IsUnique();

            modelBuilder.Entity<Vacina>()
                .HasIndex(v => v.Lote)
                .IsUnique();
        }
    }
}
