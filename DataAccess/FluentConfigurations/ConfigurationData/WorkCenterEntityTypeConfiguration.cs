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
            builder.HasMany(x => x.Units).WithOne(x => x.WorkCenter).HasForeignKey(x => x.Id);
            builder.HasOne(x => x.Area).WithMany(x => x.WorkCenters).HasForeignKey(x => x.Area.Id);
            base.Configure(builder);
        }
    }
}
