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
            builder.HasOne(ws => ws.Unit).WithMany(u => u.WorkSessions).HasForeignKey(ws => ws.UnitId);
            base.Configure(builder);
        }
    }
}
