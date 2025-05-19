using Microsoft.EntityFrameworkCore;

namespace MottuChallenge.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Teste> Teste { get; set; }
    }
}
