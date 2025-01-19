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
            builder.OwnsOne(s => s.Location, location =>
            {
                location.OwnsOne(l => l.Country, country =>
                {
                    country.Property(c => c.CountryName).HasColumnName("Country Name");
                    country.Property(c => c.CountryShortCode).HasColumnName("Short Code");
                    country.Property(c => c.PhoneCode).HasColumnName("Phone Code");
                    country.Ignore(c => c.Regions);
                    country.Ignore(c => c.CountryFlag);
                });
                location.Property(l => l.City).HasColumnName("City");
                location.Property(l => l.Address).HasColumnName("Address");
            });
            builder.OwnsOne(s => s.Email);
            builder.OwnsOne(s => s.PhoneNumber);
            builder.HasMany(s => s.Areas).WithOne(a => a.Site).HasForeignKey(a => a.Id).OnDelete(DeleteBehavior.Cascade);
            base.Configure(builder);
        }
    }
}
