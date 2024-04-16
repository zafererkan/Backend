using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sobis.Core.Entities.Concrete;

namespace Sobis.DAL.Concrete.EntityFramework.Mappings.AppUser
{
    public class AppUserMap : EntityTypeConfigurationBase<AppUserEntity>
    {
        public override void Configure(EntityTypeBuilder<AppUserEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("APP_USER");
            builder.HasKey(e => e.Id).HasName("APP_USER_PK");

            builder.HasIndex(e => e.Email, "APP_USER_UK1")
                   .IsUnique();

            builder.HasIndex(e => e.Phone, "APP_USER_UK2")
                    .IsUnique();

            builder.HasIndex(e => new { e.Email, e.Password }, "APP_USER_X1");

            builder.HasIndex(e => new { e.Phone, e.Password }, "APP_USER_X2");

            builder.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

            builder.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SURNAME");

            builder.Property(e => e.Password)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

            builder.Property(e => e.Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");

            builder.Property(e => e.Email)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");
            builder.Property(e => e.EmailConfirmed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("H")
                    .HasColumnName("EMAIL_CONFIRMED");

            builder.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

            builder.Property(e => e.DefaultCompanyId)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("DEFAULT_COMPANY_ID");
            builder.HasData(
                new AppUserEntity
                {
                    Id = 1,
                    Email = "SRDR",
                    EmailConfirmed = "E",
                    Name = "Serdar",
                    Surname = "ÖZDEMİR",
                    Password = "R6vvE51wrwp4yAo2Ld+VdQ==",
                    Phone = "0535 647 39 71",
                    Status = "E",
                    Type = 3
                }
            );
        }
    }
}
