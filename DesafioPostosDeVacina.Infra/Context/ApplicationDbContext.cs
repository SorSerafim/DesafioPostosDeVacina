using DesafioPostosDeVacina.Domain.Entities;
using DesafioPostosDeVacina.Infra.ModelTypeConfiguration;
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PostoConfiguration());
            modelBuilder.ApplyConfiguration(new VacinaConfiguration());
        }
    }
}
