using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Context;


namespace TestDataacces
{
    public class WorkCenterTest
    {
        private IWorkCenterRepository _workcenterRespository;
        private IUnitofWork _unitofWork;
        public WorkCenterTest1()
        {
            ApplicationContext context =
                new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _workcenterRespository = new IWorkCenterRepository(context);
            _unitofWork = new IUnitofWork(context);
        }
        [TestMethod]
        public void TestMethod1()
        {
            [DataRow("WorkCenter1", Area)]    //Ver metodo
            [DataRow("WorkCenter2", Area)]
            [TestMethod]
            public void Can_Add_WorkCenter(string name, Area area)
            {
                //Arrange
                Guid id = Guid  NewGuide();
                WorkCenter workcenter = new WorkCenter(name, area);

                //Execute
                _workcenterRespository.Add(workcenter); // Ver en funcion 
                _unitofWork.SaveChanges();

                //Assert
                WorkCenter? loadedWorkCenter = _workcenterRespository.GetWorkCenterById<WorkCenter>(id);// ver funcion en los repositorios 
                Assert.IsNotNull(loadedWorkCenter);
            }
        }
        [DataRow(0)]
        [TestMethod]
        public void Can_Get_WorkCenter(int position)
        {
            //Arrange
            var workcenter = _workcenterRespository.GetAllWorkCenter<WorkCenter>().ToList(); //Chekear funcion
            Assert.IsNotNull(workcenter);
            Assert.IsTrue(position < workcenter.Count);
            WorkCenter WorkCentertoGet = workcenter[position];
            //Execute
            WorkCenter? loadedWorkCenter = _workcenterRespository.GetUnitById<WorkCenter>(WorkCentertoGet.id);//Chekear Funcion 
            //Assert
            Assert.IsNotNull(loadedWorkCenter);
        }
        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_WorkCenter(int position)
        {
            //Arrange
            var workcenter = _workcenterRespository.GetAllWorkCenter<WorkCenter>().ToList(); //Chekear funcion
            Assert.IsNotNull(workcenter);
            Assert.IsTrue(position < workcenter.Count);
            WorkCenter WorkCentertoDelete = workcenter[position];
            //Execute
            _workcenterRespository.Deleteworkcenter(WorkCentertoDelete);//Chekear Funcion
            _unitofWork.SaveChanges();
            //Assert
            WorkCenter? loadedWorkCenter = _workcenterRespository.GetWorkCenterById<WorkCenter>(WorkCentertoDelete.id);//Chekear Funcion
            Assert.IsNotNull(loadedWorkCenter);
        }


    }


}
