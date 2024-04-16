using Microsoft.EntityFrameworkCore;

namespace Sobis.DAL.Concrete.EntityFramework.Contexts
{
    public class MsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=10.25.10.40;Database=SOBISPERSONEL;User Id=SOBISPERSONEL;Password=Srdr6936..; TrustServerCertificate=True");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfigurationsFromAssembly(typeof(MsDbContext).Assembly);
        }
    }
}
