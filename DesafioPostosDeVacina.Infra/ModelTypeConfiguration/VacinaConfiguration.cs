using DesafioPostosDeVacina.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioPostosDeVacina.Infra.ModelTypeConfiguration
{
    public class VacinaConfiguration : IEntityTypeConfiguration<Vacina>
    {
        public void Configure(EntityTypeBuilder<Vacina> builder)
        {
            // Configura o nome da tabela
            builder.ToTable("Vacinas");

            // Chave primária
            builder.HasKey(v => v.Id);

            // Propriedades
            builder.Property(v => v.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.Fabricante)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.Lote)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(v => v.Quantidade)
                .IsRequired();

            builder.Property(v => v.DataValidade)
                .IsRequired()
                .HasColumnType("date");

            // Chave única para o lote
            builder.HasIndex(v => v.Lote)
                .IsUnique();

            // Relacionamentos
            builder.HasOne(v => v.Posto)
                .WithMany(p => p.Vacinas)
                .HasForeignKey(v => v.PostoId);
        }
    }
}
