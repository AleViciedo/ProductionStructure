using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductionStructure.DataAccess.FluentConfigurations.Common;
using ProductionStructure.Domain.Entity.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.DataAccess.FluentConfigurations.ConfigurationData
{
    public class WorkCenterEntityTypeConfiguration : EntityTypeConfigurationBase<WorkCenter>
    {
        public override void Configure(EntityTypeBuilder<WorkCenter> builder)
        {
            builder.ToTable("Work Centers");
            builder.HasMany(wc => wc.Units).WithOne(u => u.WorkCenter).HasForeignKey(u => u.Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Area).WithMany(x => x.WorkCenters).HasForeignKey(x => x.AreaId);
            base.Configure(builder);
        }
    }
}
