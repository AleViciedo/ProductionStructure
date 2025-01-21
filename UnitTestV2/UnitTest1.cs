using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductionStructure.Domain.Entity.ConfigurationData;
using System;
using System.Collections.Generic;
using ProductionStructure.Domain.ValueObjects;
using ProductionStructure.Domain.Entity.HistoricalData;

namespace ProductionStructure.UnitTestsArea
{
    [TestClass]
    public class AreaTests
    {
        private Guid id;
        private Site? site;
        private readonly Domain.ValueObjects.Location? locationTest;

        //Inicializa una nueva instancia de Site y un Guid
        [TestInitialize]
        public void Setup()
        {
            id = Guid.NewGuid();
            site = new Site(id, "Test Site", locationTest);
        }

        //Prueba el constructor (name,site)
        [TestMethod]
        public void AreaConstructor1()
        {
            // Act
            var area = new Area("Test Area", site);

            //Assert
            Assert.AreEqual("Test Area", area.Name);
            Assert.AreEqual(site, area.Site);
        }

        //Prueba constructor (id,name,site)
        [TestMethod]
        public void AreaConstructor2()
        {
            //Act
            var area = new Area(id, "Test Area", site);

            //Assert
            Assert.AreEqual(id, area.Id);
            Assert.AreEqual(site, area.Site);
            Assert.AreEqual("Test Area", area.Name);
        }

        //Prueba de constructor (name,site,workCenter)
        [TestMethod]
        public void AreaConstructor3()
        {
            //Arrange
            var workCenters = new List<WorkCenter>();

            //Act
            var area = new Area("Test Area", site, workCenters);

            //Assert
            Assert.AreEqual("Test Area", area.Name);
            Assert.AreEqual(site, area.Site);
            Assert.AreEqual(workCenters, area.WorkCenters);
        }

        //Prueba de constructor (id,name,site,workcenter)
        [TestMethod]
        public void AreaConstructor4()
        {
            //Arrange
            var workCenters = new List<WorkCenter>();

            //Act
            var area = new Area(id, "Test Area", site, workCenters);

            //Assert
            Assert.AreEqual(id, area.Id);
            Assert.AreEqual(site, area.Site);
            Assert.AreEqual("Test Area", area.Name);
            Assert.AreEqual(workCenters, area.WorkCenters);
        }

    }
}
namespace ProductionStructure.UnitTestsSite
{
    [TestClass]
    public class SiteTests
    {
        //Constructor1 (name location)
        [TestMethod]
        public void Constructor1()
        {
            //Arrange
            var name = "Test Site";
            var location = new Location(new CountryData.Standard.Country(), "Test Region", "Test City");

            //Act
            var site = new Site(name, location);

            //Assert
            Assert.AreEqual(name, site.Name);
            Assert.IsNotNull(site);
            Assert.AreEqual(location, site.Location);
            Assert.IsNotNull(site.Areas);
            Assert.AreEqual(0, site.Areas.Count);
        }

        //Constructor2 all
        [TestMethod]
        public void Constructor2()
        {
            //Arrange
            var id = Guid.NewGuid();
            var name = "Test Site";
            var location = new Location(new CountryData.Standard.Country(), "Test Region", "Test City");
            var phoneNumber = new PhoneNumber("1234567890");
            var areas = new List<Area>();
            var email = new Email("test@example.com", "Server");

            //Act
            var site = new Site(id, name, location, email, phoneNumber, areas);

            //Assert
            Assert.IsNotNull(site);
            Assert.AreEqual(id, site.Id);
            Assert.AreEqual(name, site.Name);
            Assert.AreEqual(location, site.Location);
            Assert.AreEqual(email, site.Email);
            Assert.AreEqual(phoneNumber, site.PhoneNumber);
            Assert.AreEqual(site.Areas, areas);
        }



    }
}
namespace ProductionStructure.UnitTestsUnit
{
    [TestClass]
    public class UnitTests
    {


        //Constructor
        [TestMethod]
        public void ConstructorUnit()
        {
            //Arrange 
            Location Location1 = new Location(new CountryData.Standard.Country(), "Ciudad de las risas", "Calle 48 #4893 % C y D");
            Site Site1 = new Site("Fabrica de cosas", Location1, new Email("FabricaDeCosas", "ServerLibre.com"), new PhoneNumber("+5375342918"), new List<Area>());
            Area Area1 = new Area("Area de materias primas", Site1, new List<WorkCenter>());

            
            Guid workCenterID = Guid.NewGuid();
            WorkCenter workCenter = new WorkCenter("Derivados naturales", "Recibe y procesa componentes naturales para generar materias primas", Domain.Types.WorkMode.PerLot, Area1, new List<Unit>())
            {
            Id = workCenterID
            };

            //Act
            Unit unit = new Unit(name, workCenter);

            //Assert
            Assert.AreEqual(name,  unit.Name);
            Assert.AreEqual(workCenterID, unit.WorkCenter);

        }
        //In Use
        [TestMethod]
        public void TestMarkAsInUse()
        {
            //Arrange
            WorkCenter workCenter = new WorkCenter
            {
                Id = Guid.NewGuid()
            };
            Unit unit = new Unit("Unit",workCenter);
            unit.WorkSessions = new List<WorkSession>();

            //Act
            unit.MarkAsInUse();

            //Assert
            Assert.IsNotNull(unit.CurrentWorkSession);
            Assert.AreEqual(1, unit.WorkSessions.Count);
            Assert.AreEqual(unit.WorkSessions[0],unit.CurrentWorkSession);
            Assert.IsTrue(unit.InUse);
                           
        }

        //Not in Use
        [TestMethod]
        public void TesteMarkAsNotInUse
        {

        }


    }
}
