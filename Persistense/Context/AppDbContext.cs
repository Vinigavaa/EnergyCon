using Microsoft.EntityFrameworkCore;
using EnergyCom.Domains;

namespace Persistense.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Uc> Uc { get; set; }
        public DbSet<CalculoDados> CalculoDados { get; set; }
        public DbSet<Consumidor> Consumidor { get; set; }
        public DbSet<Fatura> Fatura { get; set; }
    }
}
