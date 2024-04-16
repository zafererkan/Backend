using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sobis.Entities.Concrete.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.DAL.Concrete.EntityFramework.Mappings.Category
{
    public class SubCategoryMap : EntityTypeConfigurationBase<SubCategoryEntity>
    {
        public override void Configure(EntityTypeBuilder<SubCategoryEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("SUB_CATEGORY");

            builder.HasKey(e => e.Id).HasName("SUB_CATEGORY_PK");

            builder.HasOne(x => x.Category).WithMany(i => i.SubCategories).HasConstraintName("SUB_CATEGORY_FK1");

            builder.Property(e => e.CategoryId)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasColumnName("CATEGORY_ID");

            builder.Property(e => e.SubCategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasColumnName("SUB_CATEGORY_NAME");
        }
    }
}
