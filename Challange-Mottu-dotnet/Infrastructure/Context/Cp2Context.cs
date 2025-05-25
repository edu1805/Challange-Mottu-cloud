using Cp2WebApplication.Domain.Entities;
using Cp2WebApplication.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Cp2WebApplication.Infrastructure.Context
{
    public class Cp2Context(DbContextOptions<Cp2Context> options) : DbContext(options)
    {
        public DbSet<Moto> Motos { get; set; }
        public DbSet<LocalizacaoAtual> LocalizacoesAtuais { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MotoMapping());
            modelBuilder.ApplyConfiguration(new LocalizacaoAtualMapping());

        }
    }
}
