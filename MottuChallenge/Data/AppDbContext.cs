using Microsoft.EntityFrameworkCore;
using MottuChallenge.Model;

namespace MottuChallenge.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Motos> Motos { get; set; }
        public DbSet<Ocupacao> Ocupacoes { get; set; }
        public DbSet<Vaga> Vagas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vaga>()
                .Property(v => v.Ocupada)
                .HasConversion<short>();

            modelBuilder.Entity<Vaga>()
                .Property(v => v.Localizacao)
                .HasMaxLength(100);
        }
    }
    
}
