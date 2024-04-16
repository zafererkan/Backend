using Microsoft.EntityFrameworkCore;

namespace Sobis.DAL.Concrete.EntityFramework.Contexts
{
    public class OraDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle("Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1522)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = SBS))); User Id = SOBIS_PERSONEL; Password = Srdr6936.;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfigurationsFromAssembly(typeof(OraDbContext).Assembly);
        }
    }
}
