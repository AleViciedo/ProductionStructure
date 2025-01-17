using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductionStructure.DataAccess.FluentConfigurations.Common;
using ProductionStructure.Domain.Entity.ConfigurationData;

namespace ProductionStructure.DataAccess.FluentConfigurations.ConfigurationData
{
    public class AreaEntityTypeConfiguration : EntityTypeConfigurationBase<Area>
    {
        public override void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.ToTable("Areas");
            builder.HasMany(a => a.WorkCenters).WithOne(wc => wc.Area).HasForeignKey(wc => wc.AreaId);
            builder.HasOne(a => a.Site).WithMany(s => s.Areas).HasForeignKey(a => a.SiteId);
            base.Configure(builder);
        }
    }
}
