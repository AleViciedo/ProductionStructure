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
    public class UnitEntityTypeConfiguration : EntityTypeConfigurationBase<Unit>
    {
        public override void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.ToTable("Units");
            builder.HasOne(x => x.WorkSession).WithOne(x => x.Unit);
            base.Configure(builder);
        }
    }
}
