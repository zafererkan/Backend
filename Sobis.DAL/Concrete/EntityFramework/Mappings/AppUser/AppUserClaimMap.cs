using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sobis.Core.Entities.Concrete;

namespace Sobis.DAL.Concrete.EntityFramework.Mappings.AppUser
{
    public class AppUserClaimMap : EntityTypeConfigurationBase<AppUserClaimEntity>
    {
        public override void Configure(EntityTypeBuilder<AppUserClaimEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("APP_USER_CLAIM");
            builder.HasKey(e => e.Id).HasName("APP_USER_CLAIM_PK");

            builder.HasIndex(e => e.AppUserId, "APP_USER_CLAIM_X1");
            builder.HasIndex(e => e.AppClaimId, "APP_USER_CLAIM_X2");

            builder.Property(e => e.AppUserId)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("APP_USER_ID");
            builder.Property(e => e.AppClaimId)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("APP_CLAIM_ID");

            builder.HasData(new AppUserClaimEntity { Id = 1, AppUserId = 1, AppClaimId = 1 });
        }
    }
}
