using AutoMapper;
using Cp2WebApplication.Domain.Entities;
using Cp2WebApplication.Infrastructure.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cp2WebApplication.Infrastructure.Mappings
{
    public class MotoMapping : IEntityTypeConfiguration<Moto>
    {
        public void Configure(EntityTypeBuilder<Moto> builder)
        {
            builder.ToTable("T_MOTOS"); // nome da tabela no Oracle

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id).HasColumnName("ID").IsRequired().ValueGeneratedOnAdd(); ;
            builder.Property(m => m.Placa).HasColumnName("PLACA").HasMaxLength(10).IsRequired();
            builder.Property(m => m.Status).HasColumnName("STATUS").HasMaxLength(50);
            builder.Property(m => m.UltimaAtualizacao).HasColumnName("ULTIMA_ATUALIZACAO");
        }
    }
}
