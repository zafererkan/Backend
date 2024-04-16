using Microsoft.EntityFrameworkCore;
using Sobis.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.DAL.Concrete.EntityFramework.Contexts
{
    public class PgDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=Srdr6936..;Host=localhost;Port=5432;Database=ECOMMERCE;Pooling=true;Connection Lifetime=0;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfigurationsFromAssembly(typeof(PgDbContext).Assembly);
        }
    }
}
