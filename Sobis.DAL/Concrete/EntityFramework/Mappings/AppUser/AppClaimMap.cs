using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sobis.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.DAL.Concrete.EntityFramework.Mappings.AppUser
{
    public class AppClaimMap : EntityTypeConfigurationBase<AppClaimEntity>
    {
        public override void Configure(EntityTypeBuilder<AppClaimEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("APP_CLAIM");
            builder.HasKey(e => e.Id).HasName("APP_CLAIM_PK");

            //builder.HasIndex(e => e.ClaimCode, "APP_CLAIM_X1");
            builder.HasIndex(e => e.ClaimCode, "APP_CLAIM_UK1").IsUnique();

            builder.Property(e => e.ClaimCode)
                    .HasMaxLength(50)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("CLAIM_CODE");

            builder.Property(e => e.ClaimName)
                    .HasMaxLength(50)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("CLAIM_NAME");

            builder.HasData(
                new AppClaimEntity
                {
                    Id = 1,
                    ClaimCode = "admin",
                    ClaimName = "Sistem Yöneticisi"
                },
                new AppClaimEntity
                {
                    Id = 2,
                    ClaimCode = "editor",
                    ClaimName = "Editör"
                },
                new AppClaimEntity
                {
                    Id = 3,
                    ClaimCode = "user",
                    ClaimName = "user"
                }
                );
        }
    }
}
