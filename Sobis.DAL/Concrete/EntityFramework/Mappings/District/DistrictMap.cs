using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sobis.Entities.Concrete.District;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.DAL.Concrete.EntityFramework.Mappings.District
{
    public class DistrictMap : EntityTypeConfigurationBase<DistrictEntity>
    {
        public override void Configure(EntityTypeBuilder<DistrictEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("DISTRICT");

            builder.HasKey(e => e.Id).HasName("DISTRICT_PK");
            builder.HasIndex(e => e.CityId, "DISTRICT_X1");

            builder.HasOne(x => x.City).WithMany(i => i.Districts).HasConstraintName("DISTRICT_FK1");

            builder.Property(e => e.CityId)
                    .IsUnicode(false)
                    .HasPrecision(2)
                    .IsRequired()
                    .HasColumnName("CITY_ID");

            builder.Property(e => e.DistrictName)
                   .IsUnicode(false)
                   .IsRequired()
                   .HasMaxLength(60)
                   .HasColumnName("DISTRICT_NAME");
        }
    }
}
