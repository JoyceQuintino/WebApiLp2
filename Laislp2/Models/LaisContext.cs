using Microsoft.EntityFrameworkCore;

namespace Laislp2.Models
{
    public class LaisContext : DbContext
    {
        public LaisContext(DbContextOptions<LaisContext> options)
            : base(options)
        {
        }
        public DbSet<Crianca> Criancas { get; set; }
        public DbSet<Mae> Maes {get; set;}
        public DbSet<Consulta> Consultas {get; set;}
        public DbSet<Parto> Partos {get; set;}
    }
}