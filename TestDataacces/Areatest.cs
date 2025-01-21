using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Context;

namespace TestDataacces
{
    [TestClass]
    public class AreaTest1
    {
        private IAreaRepository _areaRespository;
        private IUnitofWork _unitofWork;
        public AreaTest1()
        {
            ApplicationContext context = 
                new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _areaRespository = new IAreaRepository(context);
            _unitofWork = new IUnitofWork(context);
        }

        [TestMethod]
        public void TestMethod1()
        {
            [DataRow("Area1", Site)]
            [DataRow("Area2",Site)]
            [TestMethod]
            public void Can_Add_Area(string name, Site sitio)
            {
                //Arrange
                Guid id = Guid  NewGuide();
                Area area = new Area(name, sitio);

                //Execute
                _areaRespository.Add(area); // Ver en funcion 
                _unitofWork.SaveChanges();

                //Assert
                Area? loadedArea = _areaRespository.GetAreaById<Area>(id);// ver funcion en los repositorios 
                Assert.IsNotNull(loadedArea);


            }
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Get_Area(int position)
        {
            //Arrange
            var area = _areaRespository.GetAllAreas<Area>().ToList(); //Chekear funcion
            Assert.IsNotNull(area);
            Assert.IsTrue(position < area.Count);
            Area areatoGet = area[position];
            //Execute
            Area? loadedArea = _areaRespository.GetAreaById<Area>(areatoGet.id);//Chekear Funcion 
            //Assert
            Assert.IsNotNull(loadedArea);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_Area(int position)
        {
            //Arrange
            var area = _areaRespository.GetAllAreas<Area>().ToList(); //Chekear funcion
            Assert.IsNotNull(area);
            Assert.IsTrue(position < area.Count);
            Area areatoDelete = area[position];
            //Execute
            _areaRespository.DeleteArea(areatoDelete);//Chekear Funcion
            _unitofWork.SaveChanges();
            //Assert
            Area? loadedArea = _areaRespository.GetAreaById<Area>(areatoDelete.id);//Chekear Funcion
            Assert.IsNotNull(loadedArea);
        }


    }
}