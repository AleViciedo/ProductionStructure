using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Context;


namespace TestDataacces
{
    public class UnitTest
    {
        private IUnitRepository _unitRespository;
        private IUnitofWork _unitofWork;
        public UnitTest1()
        {
            ApplicationContext context =
                new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _unitRespository = new IUnitRepository(context);
            _unitofWork = new IUnitofWork(context);
        }
        [TestMethod]
        public void TestMethod1()
        {
            [DataRow("Unit1", WorkCenter)]    //Ver metodo
            [DataRow("Unit2", WorkCenter)]
            [TestMethod]
            public void Can_Add_Unit(string name, WorkCenter workcenter)
            {
                //Arrange
                Guid id = Guid  NewGuide();
                Unit unit = new Unit(name, workcenter);

                //Execute
                _unitRespository.Add(unit); // Ver en funcion 
                _unitofWork.SaveChanges();

                //Assert
                Unit? loadedUnit = _unitRespository.GetUnitById<Unit>(id);// ver funcion en los repositorios 
                Assert.IsNotNull(loadedUnit);
            }
        }
        [DataRow(0)]
        [TestMethod]
        public void Can_Get_Unit(int position)
        {
            //Arrange
            var unit = _unitRespository.GetAllUnit<Unit>().ToList(); //Chekear funcion
            Assert.IsNotNull(unit);
            Assert.IsTrue(position < unit.Count);
            Unit UnittoGet = unit[position];
            //Execute
            Unit? loadedUnit = _unitRespository.GetUnitById<Unit>(UnittoGet.id);//Chekear Funcion 
            //Assert
            Assert.IsNotNull(loadedUnit);
        }
        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_Unit(int position)
        {
            //Arrange
            var unit = _unitRespository.GetAllUnite<Unite>().ToList(); //Chekear funcion
            Assert.IsNotNull(unit);
            Assert.IsTrue(position < unit.Count);
            Unite unitetoDelete = unit[position];
            //Execute
            _unitRespository.Deleteunite(unitetoDelete);//Chekear Funcion
            _unitofWork.SaveChanges();
            //Assert
            Unite? loadedUnite = _uniteRespository.GetUniteById<Unite>(unitetoDelete.id);//Chekear Funcion
            Assert.IsNotNull(loadedUnite);
        }


    }


}
