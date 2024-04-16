using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sobis.Entities.Concrete.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.DAL.Concrete.EntityFramework.Mappings.City
{
    public class CityMap : EntityTypeConfigurationBase<CityEntity>
    {
        public override void Configure(EntityTypeBuilder<CityEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("CITY");
            builder.HasKey(e => e.Id).HasName("CITY_PK");

            builder.HasIndex(e => e.PlaneNo, "CITY_X1");

            builder.Property(e => e.PlaneNo)
                   .IsUnicode(false)
                   .HasMaxLength(2)
                   .HasColumnName("PLATE_NO");

            builder.Property(e => e.CityName)
                   .IsUnicode(false)
                   .HasMaxLength(60)
                   .IsRequired()
                   .HasColumnName("CITY_NAME");
        }
    }
}
