using Cp2WebApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cp2WebApplication.Infrastructure.Mappings
{
    public class LocalizacaoAtualMapping : IEntityTypeConfiguration<LocalizacaoAtual>
    {
        public void Configure(EntityTypeBuilder<LocalizacaoAtual> builder)
        {
            builder.ToTable("T_LOCALIZACAO_ATUAL");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.CoordenadaX).IsRequired();
            builder.Property(l => l.CoordenadaY).IsRequired();
            builder.Property(l => l.DataHoraAtualizacao).IsRequired();

            builder.HasOne(l => l.Moto)
                   .WithMany()
                   .HasForeignKey(l => l.MotoId);
        }
    }

}
