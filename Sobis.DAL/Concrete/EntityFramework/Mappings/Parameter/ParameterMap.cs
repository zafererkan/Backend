using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sobis.Entities.Concrete.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.DAL.Concrete.EntityFramework.Mappings.Parameter
{
    public class ParameterMap : EntityTypeConfigurationBase<ParameterEntity>
    {
        public override void Configure(EntityTypeBuilder<ParameterEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("PARAMETER");
            builder.HasKey(e => e.Id).HasName("PARAMETER_PK");

            builder.Property(e => e.ParamName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasColumnName("PARAM_NAME");

            builder.HasData(new ParameterEntity
            {
                Id = 1,
                ParamName = "Product Type Id",
                Status = "E"                
            });
        }
    }
}
