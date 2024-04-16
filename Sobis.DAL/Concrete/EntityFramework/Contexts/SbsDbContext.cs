using Microsoft.EntityFrameworkCore;
using Sobis.Core.Entities.Concrete;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Sobis.DAL.Concrete.EntityFramework.Contexts
{
    public class SbsDbContext : DbContext
    {
        //public SbsDbContext(DbContextOptions<SbsDbContext> options) : base(options)
        //{

        //}
        //public SbsDbContext()
        //{
        //    var appSettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        //    Dboptions.DbType = appSettings["SbsDbOptions:DbType"];
        //    Dboptions.DbName = appSettings["SbsDbOptions:DbName"];
        //    Dboptions.DbUser = appSettings["SbsDbOptions:DbUser"];
        //    Dboptions.DbPassword = appSettings["SbsDbOptions:DbPassword"];
        //}
        //private DbOptions GetAppSettings()
        //{
        //    var appSettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        //    DbOptions dbOptions = new DbOptions
        //    {
        //        DbType = appSettings["SbsDbOptions:DbType"],
        //        DbName = appSettings["SbsDbOptions:DbName"],
        //        DbUser = appSettings["SbsDbOptions:DbUser"],
        //        DbPassword = appSettings["SbsDbOptions:DbPassword"],
        //    };
        //    return dbOptions;
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                //DbOptions dbOptions = GetAppSettings();

                if (Dboptions.DbType == "ORACLE")
                {
                    optionsBuilder.UseOracle("Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1522)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = SBS))); User Id = SOBIS_PERSONEL; Password = Srdr6936.;")
                        .EnableSensitiveDataLogging();
                }
                else if (Dboptions.DbType == "MSSQL")
                {
                    optionsBuilder.UseSqlServer(@"Server=10.25.10.40;Database=SOBISPERSONEL;User Id=SOBISPERSONEL;Password=Srdr6936..; TrustServerCertificate=True")
                        .EnableSensitiveDataLogging();
                }
                else if (Dboptions.DbType == "POSTGRE")
                {
                    optionsBuilder.UseNpgsql("User ID=postgres;Password=Srdr6936..;Host=localhost;Port=5432;Database=ECOMMERCE;Pooling=true;Connection Lifetime=0;")
                        .EnableSensitiveDataLogging();
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //DbOptions dbOptions = GetAppSettings();

            if (Dboptions.DbType == "ORACLE")
            {
                _ = modelBuilder.ApplyConfigurationsFromAssembly(typeof(OraDbContext).Assembly);
            }
            else if (Dboptions.DbType == "MSSQL")
            {
                _ = modelBuilder.ApplyConfigurationsFromAssembly(typeof(MsDbContext).Assembly);
            }
            else if (Dboptions.DbType == "POSTGRE")
            {
                _ = modelBuilder.ApplyConfigurationsFromAssembly(typeof(PgDbContext).Assembly);
            }

            modelBuilder.AddAllDbSet();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var insertedEntries = this.ChangeTracker.Entries()
                               .Where(x => x.State == EntityState.Added)
                               .Select(x => x.Entity);

            foreach (var insertedEntry in insertedEntries)
            {
                var entityBase = insertedEntry as EntityBase;
                //If the inserted object is an Auditable. 
                if (entityBase != null)
                {
                    entityBase.CrDate = DateTime.UtcNow;
                }
            }

            var modifiedEntries = this.ChangeTracker.Entries()
                   .Where(x => x.State == EntityState.Modified)
                   .Select(x => x.Entity);

            foreach (var modifiedEntry in modifiedEntries)
            {
                //If the inserted object is an Auditable. 
                var entityBase = modifiedEntry as EntityBase;
                if (entityBase != null)
                {
                    entityBase.ModDate = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
