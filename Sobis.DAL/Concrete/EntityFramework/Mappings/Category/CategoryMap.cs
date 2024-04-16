using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sobis.Entities.Concrete;

namespace Sobis.DAL.Concrete.EntityFramework.Mappings.Category
{
    public class CategoryMap : EntityTypeConfigurationBase<CategoryEntity>
    {
        public override void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("CATEGORY");

            builder.HasKey(e => e.Id).HasName("CATEGORY_PK");            

            builder.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasColumnName("NAME");

            builder.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");
        }
    }
}
