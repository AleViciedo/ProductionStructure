using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using ProductionStructure.Domain.Common;
using ProductionStructure.DataAccess.FluentConfigurations.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using ProductionStructure.DataAccess.FluentConfigurations.ConfigurationData;
using CountryData.Standard;
using System.Linq;

namespace TestAreaEntityTypeConfig
{
    //Definición de las Entidades
    public class Area : Entity 
    {    
        public string Name { get; set; } 
        public ICollection<WorkCenter> WorkCenters { get; set; } 
        public Site Site { get; set; } 
        public int SiteId { get; set; } 
    }
    public class WorkCenter : Entity 
    {    
        public string Name { get; set; } 
        public Area Area { get; set; } 
        public int AreaId { get; set; }
    }
    public class Site : Entity 
    { 
        public string Name { get; set; } 
        public ICollection<Area> Areas { get; set; }
    }

    //Crear un TestDbContext
    public class TestDbContext : DbContext 
    { 
        public DbSet<Area> Areas { get; set; } 
        public DbSet<WorkCenter> WorkCenters { get; set; } 
        public DbSet<Site> Sites { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            modelBuilder.ApplyConfiguration(new AreaEntityTypeConfiguration()); 
        } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        { 
            optionsBuilder.UseInMemoryDatabase("TestDatabase"); 
        } 
    }
    [TestClass]
    public class AreaEntityTypeConfigurationTests
    {
        [TestMethod]
        public void Area_Should_Have_Correct_Table_Name()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            using (var context = new TestDbContext(options))
            { 
                // Act: initialize the context
                context.Database.EnsureCreated();
                
                // Get the metadata
                var entityType = context.Model.FindEntityType(typeof(Area));
                
                // Assert: check if table name is correct
                Assert.AreEqual("Areas", entityType.GetTableName());
            } 
        } 
        [TestMethod] 
        public void Area_Should_Have_Many_WorkCenters() 
        { 
            var options = new DbContextOptionsBuilder<TestDbContext>() 
                .UseInMemoryDatabase(databaseName: "TestDatabase") 
                .Options;
            using (var context = new TestDbContext(options)) 
            { 
                // Act: initialize the context
                context.Database.EnsureCreated();
                
                // Get the metadata
                var entityType = context.Model.FindEntityType(typeof(Area)); 
                var navigation = entityType.FindNavigation(nameof(Area.WorkCenters));
                
                // Assert: check if WorkCenters navigation is configured properly
                Assert.IsNotNull(navigation);
                Assert.IsTrue(navigation.IsCollection);
                Assert.AreEqual(navigation.ForeignKey.DeleteBehavior, DeleteBehavior.Cascade);
            } 
        } 
        [TestMethod] 
        public void Area_Should_Have_One_Site() 
        { 
            var options = new DbContextOptionsBuilder<TestDbContext>() 
                .UseInMemoryDatabase(databaseName: "TestDatabase") 
                .Options; 
            using (var context = new TestDbContext(options)) 
            { 
                // Act: initialize the context
                context.Database.EnsureCreated();
                
                // Get the metadata
                var entityType = context.Model.FindEntityType(typeof(Area));
                var navigation = entityType.FindNavigation(nameof(Area.Site));
                
                // Assert: check if Site navigation is configured properly
                Assert.IsNotNull(navigation); 
                Assert.IsTrue(navigation.IsOnDependent); 
                Assert.AreEqual(navigation.ForeignKey.DeleteBehavior, DeleteBehavior.ClientSetNull); 
            } 
        }
        
    }
}
namespace TestSitioEntityTypeConfig
{
        public class Site : Entity 
        { 
            public string Name { get; set; } 
            public Location Location { get; set; } 
            public Email Email { get; set; } public 
                PhoneNumber PhoneNumber { get; set; } 
            public ICollection<Area> Areas { get; set; } 
        }
        public class Location 
        { 
            public Country Country { get; set; } 
            public string City { get; set; } 
            public string Address { get; set; }
        }
        public class Country 
        { public string CountryName { get; set; }
            public string CountryShortCode { get; set; } 
            public string PhoneCode { get; set; }
            public ICollection<Regions> Regions { get; set; } 
            public string CountryFlag { get; set; } }
        public class Email 
        { 
            public string Value { get; set; } 
        }
        public class PhoneNumber 
        { 
            public string Value { get; set; } 
        }
        public class Area : Entity
        {
            public string Name { get; set; }
            public Site Site { get; set; }
            public int SiteId { get; set; }
        }
    public class TestDbContext : DbContext 
    { 
        public DbSet<Site> Sites { get; set; } 
        public DbSet<Area> Areas { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            modelBuilder.ApplyConfiguration(new SiteEntityTypeConfiguration()); 
        } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        { 
            optionsBuilder.UseInMemoryDatabase("TestDatabase"); 
        } 
    }

    [TestClass]
    public class SiteEntityTypeConfigurationTests
    {
        [TestMethod] 
        public void Site_Should_Have_Correct_Table_Name() 
        { 
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options; using (var context = new TestDbContext(options)) 
            { 
                context.Database.EnsureCreated();
                var entityType = context.Model.FindEntityType(typeof(Site)); 
                Assert.AreEqual("Sites", entityType.GetTableName()); 
            } 
        }

        [TestMethod]
        public void Site_Should_Have_Owned_Properties_Configured()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options; using (var context = new TestDbContext(options))
            {
                context.Database.EnsureCreated(); 
                var entityType = context.Model.FindEntityType(typeof(Site)); 
                var locationNavigation = entityType.FindNavigation(nameof(Site.Location)); 
                var countryNavigation = entityType.FindNavigation(nameof(Location.Country)); 
                // Assert that the navigation and owned types are configured correctly
                Assert.IsNotNull(locationNavigation); 
                Assert.IsNotNull(countryNavigation); 
            } 
        }

        [TestMethod] 
        public void Site_Should_Have_One_To_Many_Relationship_With_Area() 
        { 
            var options = new DbContextOptionsBuilder<TestDbContext>() .UseInMemoryDatabase(databaseName: "TestDatabase") 
                .Options; 
            using (var context = new TestDbContext(options)) 
            { 
                context.Database.EnsureCreated();
                var entityType = context.Model.FindEntityType(typeof(Site)); 
                var navigation = entityType.FindNavigation(nameof(Site.Areas)); 
                // Assert the navigation is configured properly
                Assert.IsNotNull(navigation);
                Assert.IsTrue(navigation.IsCollection);
                Assert.AreEqual(navigation.ForeignKey.DeleteBehavior, DeleteBehavior.Cascade); 
            } 
        } 
        [TestMethod]
        public void Site_Should_Map_Correct_Owned_Properties() 
        { 
            var options = new DbContextOptionsBuilder<TestDbContext>() 
                .UseInMemoryDatabase(databaseName: "TestDatabase") 
                .Options; 
            using (var context = new TestDbContext(options)) 
            { 
                context.Database.EnsureCreated(); 
                var entityType = context.Model.FindEntityType(typeof(Site)); 
                var locationOwned = entityType.FindNavigation(nameof(Site.Location))
                    .ForeignKey.DeclaringEntityType;
                var columns = locationOwned.GetProperties()
                    .Select(p => p.Name).ToList(); 
                Assert.IsTrue(columns.Contains("City"));
                Assert.IsTrue(columns.Contains("Address")); 
                Assert.IsTrue(columns.Contains("Country Name")); 
                Assert.IsTrue(columns.Contains("Short Code")); 
                Assert.IsTrue(columns.Contains("Phone Code")); 
            } 
        } 
    }          
}


