using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;
using ProductionStructure.DataAccess.FluentConfigurations.ConfigurationData;
using ProductionStructure.DataAccess.FluentConfigurations.HistoricalData;
using ProductionStructure.Domain.Entity.ConfigurationData;
using ProductionStructure.Domain.Entity.HistoricalData;


namespace DataAccess.Context
{
    public class ApplicationContext : DbContext
    {
        #region Tables
        public DbSet<Site> Sites { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<WorkCenter> WorkCenters { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<WorkSession> WorkSessions { get; set; }
        #endregion

        #region Constructors
        public ApplicationContext()
        {
        }
        public ApplicationContext(string connectionString) : base(GetOptions(connectionString))
        {
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        #endregion

        #region Overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SiteEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AreaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WorkCenterEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UnitEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WorkSessionEntityTypeConfiguration());
        }

        //public override EntityEntry Add(object entity)
        //{
        //    return base.Add(entity);
        //}
        #endregion

        #region Helpers
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqliteDbContextOptionsBuilderExtensions.UseSqlite(new DbContextOptionsBuilder(), connectionString).Options;
        }
        #endregion
    }
}
