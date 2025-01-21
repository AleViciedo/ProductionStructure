using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Context;


namespace TestDataacces
{
    public class SitioTest
    {
        private ISiteRepository _siteRespository;
        private IUnitofWork _unitofWork;
        public SiteTest1()
        {
            ApplicationContext context =
                new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _siteRespository = new ISiteRepository(context);
            _unitofWork = new IUnitofWork(context);
        }
        [TestMethod]
        public void TestMethod1()
        {
            [DataRow("Site1", Location)]    //Ver metodo
            [DataRow("Site2", Location)]
            [TestMethod]
            public void Can_Add_Site(string name, Location location)
            {
                //Arrange
                Guid id = Guid  NewGuide();
                Site site = new Site(name, location);

                //Execute
                _siteRespository.Add(site); // Ver en funcion 
                _unitofWork.SaveChanges();

                //Assert
                Site? loadedSite = _siteRespository.GetSiteById<Site>(id);// ver funcion en los repositorios 
                Assert.IsNotNull(loadedSite);
            }
        }
        [DataRow(0)]
        [TestMethod]
        public void Can_Get_Site(int position)
        {
            //Arrange
            var site = _siteRespository.GetAllSites<Site>().ToList(); //Chekear funcion
            Assert.IsNotNull(site);
            Assert.IsTrue(position < site.Count);
            Site SitetoGet = site[position];
            //Execute
            Site? loadedSite = _siteRespository.GetSiteById<Site>(SitetoGet.id);//Chekear Funcion 
            //Assert
            Assert.IsNotNull(loadedSite);
        }
        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_Site(int position)
        {
            //Arrange
            var site = _siteRespository.GetAllSite<Site>().ToList(); //Chekear funcion
            Assert.IsNotNull(site);
            Assert.IsTrue(position < site.Count);
            Site sitetoDelete = site[position];
            //Execute
            _siteRespository.DeleteSite(sitetoDelete);//Chekear Funcion
            _unitofWork.SaveChanges();
            //Assert
            Site? loadedSite = _siteRespository.GetSiteById<Site>(sitetoDelete.id);//Chekear Funcion
            Assert.IsNotNull(loadedSite);
        }


    }


}
