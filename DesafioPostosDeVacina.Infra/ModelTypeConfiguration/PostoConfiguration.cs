using DesafioPostosDeVacina.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioPostosDeVacina.Infra.ModelTypeConfiguration
{
    internal class PostoConfiguration : IEntityTypeConfiguration<Posto>
    {
        public void Configure(EntityTypeBuilder<Posto> builder)
        {
            // Configura o nome da tabela
            builder.ToTable("Postos");

            // Chave primária
            builder.HasKey(p => p.Id);

            // Propriedades
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            // Relacionamentos
            builder.HasMany(p => p.Vacinas)
                .WithOne(v => v.Posto)
                .HasForeignKey(v => v.PostoId);
                //.OnDelete(DeleteBehavior.Restrict);
        }
    }
}
