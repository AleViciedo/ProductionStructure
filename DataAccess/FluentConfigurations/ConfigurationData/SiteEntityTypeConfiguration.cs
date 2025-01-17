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
    public class SiteEntityTypeConfiguration : EntityTypeConfigurationBase<Site>
    {
        public override void Configure(EntityTypeBuilder<Site> builder)
        {
            builder.ToTable("Sites");
            builder.OwnsOne(x => x.Location);
            builder.OwnsOne(x => x.Email);
            builder.OwnsOne(x => x.PhoneNumber);
            builder.HasMany(x => x.Areas).WithOne(x => x.Site).HasForeignKey(x => x.Id);
            base.Configure(builder);
        }
    }
}
