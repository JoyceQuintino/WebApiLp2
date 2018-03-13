using Microsoft.EntityFrameworkCore;
using Laislp2.Models;

namespace Laislp2.Models
{
    public class LaisContext : DbContext
    {
        public DbSet<Crianca> Criancas { get; set;}
        public DbSet<Mae> Maes {get; set;}
        public DbSet<Consulta> Consultas {get; set;}
        public DbSet<Parto> Partos {get; set;}
        public DbSet<MaeConsulta> MaeConcultas {get; set;}

        public LaisContext(DbContextOptions<LaisContext> options)
            : base(options)
        {
        }

         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaeConsulta>()
                .HasKey(mc => new { mc.IdMae, mc.IdConsulta});
        }
    }
}