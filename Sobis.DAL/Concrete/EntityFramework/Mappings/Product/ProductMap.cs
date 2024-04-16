using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sobis.Entities.Concrete.Product;

namespace Sobis.DAL.Concrete.EntityFramework.Mappings.Product
{
    public class ProductMap : EntityTypeConfigurationBase<ProductEntity>
    {
        public override void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("PRODUCT");
            builder.HasKey(e => e.Id).HasName("PRODUCT_PK");

            builder.HasIndex(e => e.CategoryId, "PRODUCT_X1");
            builder.HasIndex(e => e.ProductName, "PRODUCT_X2");
            builder.HasIndex(e => e.SubCategoryId, "PRODUCT_X3");

            builder.HasOne(x => x.Category).WithMany(i => i.Products).HasConstraintName("PRODUCT_FK1");
            builder.HasOne(x => x.SubCategory).WithMany(i => i.Products).HasConstraintName("PRODUCT_FK2");

            builder.Property(e => e.ProductName)
                   .IsUnicode(false)
                   .HasMaxLength(200)
                   .IsRequired()
                   .HasColumnName("PRODUCT_NAME");

            builder.Property(e => e.CategoryId)
                   .IsUnicode(false)
                   .IsRequired()
                   .HasColumnName("CATEGORY_ID");

            builder.Property(e => e.SubCategoryId)
                   .IsUnicode(false)
                   .HasColumnName("SUB_CATEGORY_ID");

            builder.Property(e => e.Description)
                   .IsUnicode(false)
                   .HasMaxLength(500)
                   .HasColumnName("DESCRIPTION");

            builder.Property(e => e.MinBudget)
                   .IsUnicode(false)
                   .HasColumnName("MIN_BUDGET");

            builder.Property(e => e.MaxBudget)
                   .IsUnicode(false)
                   .HasColumnName("MAX_BUDGET");

            builder.Property(e => e.MaxBudget)
                   .IsUnicode(false)
                   .HasColumnName("MAX_BUDGET");

            builder.Property(e => e.CityId)
                  .IsUnicode(false)
                  .HasColumnName("CITY_ID");

            builder.Property(e => e.DistrictId)
                  .IsUnicode(false)
                  .HasColumnName("DISTRICT_ID");

            builder.Property(e => e.ProductTypeId)
                  .IsUnicode(false)
                  .HasColumnName("PRODUCT_TYPE_ID");
        }
    }
}
