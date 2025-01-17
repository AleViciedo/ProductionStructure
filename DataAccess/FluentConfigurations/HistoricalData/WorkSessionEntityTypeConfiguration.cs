using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductionStructure.DataAccess.FluentConfigurations.Common;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.DataAccess.FluentConfigurations.HistoricalData
{
    public class WorkSessionEntityTypeConfiguration : EntityTypeConfigurationBase<WorkSession>
    {
        public override void Configure(EntityTypeBuilder<WorkSession> builder)
        {
            builder.ToTable("Work Sessions");
            builder.HasOne(x => x.Unit).WithMany().HasForeignKey(x => x.Unit);
            base.Configure(builder);
        }
    }
}
