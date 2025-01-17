using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductionStructure.DataAccess.FluentConfigurations.Common;
using ProductionStructure.Domain.Entity.ConfigurationData;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.DataAccess.FluentConfigurations.ConfigurationData
{
    public class UnitEntityTypeConfiguration : EntityTypeConfigurationBase<Unit>
    {
        public override void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.ToTable("Units");
            builder.HasOne(u => u.WorkCenter).WithMany(wc => wc.Units).HasForeignKey(u => u.WorkCenterId);
            builder.HasMany(u => u.WorkSessions).WithOne(ws => ws.Unit).HasForeignKey(ws => ws.UnitId);
            builder.HasOne(u => u.CurrentWorkSession).WithOne().HasForeignKey<WorkSession>(ws => ws.UnitId);
            base.Configure(builder);
        }
    }
}
