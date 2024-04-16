using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sobis.Core.Entities.Concrete;

namespace Sobis.DAL.Concrete.EntityFramework.Mappings
{
    public abstract class EntityTypeConfigurationBase<TBase> : IEntityTypeConfiguration<TBase> where TBase : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<TBase> builder)
        {
            builder.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("E")
                    .HasColumnName("STATUS");

            builder.Property(e => e.CrDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CR_DATE");

            builder.Property(e => e.CrUser)
                    .HasColumnName("CR_USER");

            builder.Property(e => e.ModDate)
                    .HasColumnType("DATE")
                    .HasColumnName("MOD_DATE");

            builder.Property(e => e.ModUser)
                    .HasColumnName("MOD_USER");
        }
    }
}
