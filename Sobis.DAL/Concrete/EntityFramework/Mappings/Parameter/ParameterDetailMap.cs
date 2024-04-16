using Autofac.Features.OwnedInstances;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sobis.Entities.Concrete.Parameter;
using System.Drawing.Drawing2D;

namespace Sobis.DAL.Concrete.EntityFramework.Mappings.Parameter
{
    public class ParameterDetailMap : EntityTypeConfigurationBase<ParameterDetailEntity>
    {
        public override void Configure(EntityTypeBuilder<ParameterDetailEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("PARAMETER_DETAIL");
            builder.HasKey(e => e.Id).HasName("PARAMETER_DETAIL_PK");

            builder.HasIndex(e => e.ParamId, "PARAMETER_DETAIL_X1");

            builder.HasOne(e => e.Param).
                WithMany(w => w.ParametreDetails).
                HasConstraintName("PARAMETER_DETAIL_FK1");

            builder.Property(e => e.ParamDetailName)
                   .IsUnicode(false)
                   .HasMaxLength(60)
                   .IsRequired()
                   .HasColumnName("PARAM_DETAIL_NAME");



            builder.Property(e => e.ParamId)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasColumnName("PARAM_ID");

            builder.Property(e => e.Data)
                   .IsUnicode(false)
                   .IsRequired()
                   .HasColumnName("DATA");

            builder.Property(e => e.DataValue)
                   .IsUnicode(false)
                   .HasMaxLength(10)
                   .HasColumnName("DATA_VALUE");

            builder.Property(e => e.OrderNo)
                   .IsUnicode(false)
                   .IsRequired(false)
                   .HasColumnName("ORDER_NO");

            builder.Property(e => e.ParentDataId)
                   .IsUnicode(false)
                   .IsRequired(false)
                   .HasColumnName("PARENT_DATA_ID");

            builder.HasData(new ParameterDetailEntity
            {

                Id = 1,
                ParamId = 1,
                ParamDetailName = "New Brand",
                Data = 1,
                Status = "E",

            },
            new ParameterDetailEntity
            {

                Id = 2,
                ParamId = 1,
                ParamDetailName = "Pre Owned",
                Data = 2,
                Status = "E"
            }
            );
        }
    }
}
