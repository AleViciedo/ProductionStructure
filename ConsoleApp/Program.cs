using System;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using ProductionStructure.Domain.Entity.ConfigurationData;
using ProductionStructure.Domain.ValueObjects;
using ProductionStructure.Domain.Entity.HistoricalData;
using ProductionStructure.DataAccess;
using ProductionStructure.DataAccess.Repositories.ConfigurationData;
using ProductionStructure.DataAccess.Repositories.HistoricalData;
using CountryData.Standard;
using ProductionStructure.GrpcProtos;
using Grpc.Net.Client;
using Google.Protobuf.WellKnownTypes;
using System.ComponentModel.DataAnnotations.Schema;
using ProductionStructure.DataAccess.Context;

namespace ProductionStructure.ConsoleApp
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            #region Area Interfaz
            Console.WriteLine("Presione una tecla para conectar");
            Console.ReadKey();

            Console.WriteLine("Creating channel and client");
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress("http://localhost:5051", new GrpcChannelOptions { HttpHandler = httpHandler });
            if (channel is null)
            {
                Console.WriteLine("Cannot connect");
                channel.Dispose();
                return;
            }

            var site = new ProductionStructure.GrpcProtos.Area.AreaClient(channel);

            Console.WriteLine("Presione una tecla para crear un area");
            Console.ReadKey();
            var createResponse = site.CreateArea(new CreateAreaRequest()
            {
                Name = "Area54"
            });

            if (createResponse is null)
            {
                Console.WriteLine("Cannot create area");
                channel?.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Successful creation");
            }

            Console.WriteLine("Presione una tecla para obtener todas las areas");
            Console.ReadKey();
            var getResponse = GetAllAreas(new Google.Protobuf.WellKnownTypes.Empty());
            if (getResponse is null)
            {
                Console.WriteLine("Cannot get areas");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtencion exitosa de {getResponse} areas");
            }

            Console.WriteLine($"Presione una tecla para obtener un Area por Id{getResponse.Id} ");

            Console.WriteLine("Presione una tecla para eliminar el area");
            Console.ReadKey();

            site.DeleteArea(new DeleteRequest){ Id = createResponse.Id});
            var deletedGetResponse = site.GetArea(new GetRequest() { Id = createResponse.Id });
            if(deletedGetResponse is null || deletedGetResponse.KindCase != NullableAreaDTO.KindOneofCase.Area)
            {
                Console.WriteLine($"Successful elimation");
            }
            channel.Dispose() ;
            #endregion
            /////////////////////////////////////////////////////////////////////////////////////////////Verificar 
            #region WorkCenter Interfaz
            Console.WriteLine("Presione una tecla para conectar");
            Console.ReadKey();

            Console.WriteLine("Creating channel and client");
            var httpHandler2 = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel2 = GrpcChannel.ForAddress("http://localhost:5051", new GrpcChannelOptions { HttpHandler = httpHandler2 });
            if (channel2 is null)
            {
                Console.WriteLine("Cannot connect");
                channel2.Dispose();
                return;
            }

            var area = new ProductionStructure.GrpcProtos.WorkCenter.WorkCenterClient(channel2);

            Console.WriteLine("Presione una tecla para crear un Centro de Trabajo");
            Console.ReadKey();
            var createResponse1 = area.CreateWorkCenter(new CreateWorkCenterRequest()
            {
                Name = "WorkCenter1"
                Description // Crear una descripcion y un modo de trabajo dentro del metodo CreatWorkCenterRequest
            }); ;

            if (createResponse1 is null)
            {
                Console.WriteLine("Cannot create Work Center");
                channel2?.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Successful creation");
            }

            Console.WriteLine("Presione una tecla para obtener todas los Centros de Trabajos");
            Console.ReadKey();
            var getResponse1 = GetAllWorkCenters(new Google.Protobuf.WellKnownTypes.Empty());
            if (getResponse1 is null)
            {
                Console.WriteLine("Cannot get WorkCenter");
                channel2.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtencion exitosa de {getResponse1} WorkCenter");
            }

            Console.WriteLine($"Presione una tecla para obtener un WorkCenter por Id{getResponse1.Id} ");

            Console.WriteLine("Presione una tecla para eliminar el WorkCenter");
            Console.ReadKey();

            area.DeleteWorkCenter(new DeleteRequest{ Id = createResponse1.Id});
            var deletedGetResponse1 = area.CreateWorkCenter(new GetRequest() { Id = createResponse1.Id });
            if (deletedGetResponse1 is null || deletedGetResponse1.KindCase != NullableWorkCenterDTO.KindOneofCase.WorkCenter)//BAteo
            {
                Console.WriteLine($"Successful elimation");
            }
            channel.Dispose();
            #endregion

            #region Example DB
            ApplicationContext context = new ApplicationContext("Data Source=ProductionStructureDB.sqlite");
            if (!context.Database.CanConnect())
                context.Database.Migrate();
            Location Location1 = new Location(new CountryData.Standard.CountryHelper().GetCountryByCode("CU"), "Ciudad de las risas", "Calle 48 #4893 % C y D");
            Site Site1 = new Site("Fabrica de cosas", Location1, new Email("FabricaDeCosas", "ServerLibre.com"), new PhoneNumber("+5375342918"), new List<Area>());
            Area Area1 = new Area("Area de materias primas", Site1, new List<WorkCenter>());
            Area Area2 = new Area("Area de manufactura", Site1, new List<WorkCenter>());
            WorkCenter WorkCenter1 = new WorkCenter("Derivados naturales","Recibe y procesa componentes naturales para generar materias primas", Domain.Types.WorkMode.PerLot , Area1, new List<Unit>());
            WorkCenter WorkCenter2 = new WorkCenter("Derivados industriales", "Recibe y procesa componentes industriales y quimiicos para generar materias primas", Domain.Types.WorkMode.PerLot, Area1, new List<Unit>());
            WorkCenter WorkCenter3 = new WorkCenter("Imprenta", "Imprime cosas", Domain.Types.WorkMode.Continuous, Area2, new List<Unit>());
            WorkCenter WorkCenter4 = new WorkCenter("Post-procesado", "Arregla, encuaderna y personaliza impresiones", Domain.Types.WorkMode.Discrete, Area2, new List<Unit>());
            Unit Unit1 = new Unit("Maquina de hacer papel", "Maquinadores3000", "Maquina que prensa madera fina hasta hacerla papel", WorkCenter1,null,new List<WorkSession>());
            Unit Unit2 = new Unit("Maquina de hacer hilo", "Maquinadores3000", "Trenza algodon para hacer hilo", WorkCenter1, null, new List<WorkSession>());
            Unit Unit3 = new Unit("Maquina de hacer tinta", "Kinkeya", "Maquina que convierte quimicos en tinta", WorkCenter2, null, new List<WorkSession>());
            Unit Unit4 = new Unit("Maquina de hacer plastico","Kinkeya", "Destila petroleo y hace plastico", WorkCenter2, null, new List<WorkSession>());
            Unit Unit5 = new Unit("Impresora Industrial", "Laticaso", null, WorkCenter3, null, new List<WorkSession>());
            Unit Unit6 = new Unit("Maquina de corte, ajusto y control", "Laticaso", null, WorkCenter3, null, new List<WorkSession>());
            Unit Unit7 = new Unit("Encuadernadora", "Lucrecio & Pancracio", null, WorkCenter4, null, new List<WorkSession>());
            Unit Unit8 = new Unit("Estacion de personalizacion", "Lucrecio & Pancracio", null, WorkCenter4, null, new List<WorkSession>());
            WorkCenter1.Units.Add(Unit1);
            WorkCenter1.Units.Add(Unit2);
            WorkCenter2.Units.Add(Unit3);
            WorkCenter2.Units.Add(Unit4);
            WorkCenter3.Units.Add(Unit5);
            WorkCenter3.Units.Add(Unit6);
            WorkCenter4.Units.Add(Unit7);
            WorkCenter4.Units.Add(Unit8);
            Area1.WorkCenters.Add(WorkCenter1);
            Area1.WorkCenters.Add(WorkCenter2);
            Area2.WorkCenters.Add(WorkCenter3);
            Area2.WorkCenters.Add(WorkCenter4);
            Site1.Areas.Add(Area1);
            Site1.Areas.Add(Area2);
            context.Sites.Add(Site1);
            context.Areas.Add(Area1);
            context.Areas.Add(Area2);
            context.WorkCenters.Add(WorkCenter1);
            context.WorkCenters.Add(WorkCenter2);
            context.WorkCenters.Add(WorkCenter3);
            context.WorkCenters.Add(WorkCenter4);
            context.Units.Add(Unit1);
            context.Units.Add(Unit2);
            context.Units.Add(Unit3);
            context.Units.Add(Unit4);
            context.Units.Add(Unit5);
            context.Units.Add(Unit6);
            context.Units.Add(Unit7);
            context.Units.Add(Unit8);

            context.SaveChanges();
            #endregion

            #region CRUD Tests
            //Unit? ReadUnit = context.Set<Unit>().FirstOrDefault(u => u.Id == Unit3.Id);
            //Area? ReadArea = context.Set<Area>().FirstOrDefault(a => a.Id == Area1.Id);

            //Console.ReadLine();

            //Unit3.Description = "Maquina que hace tinta con alcohol";
            //context.Units.Update(Unit3);
            //context.SaveChanges();

            //ReadUnit = context.Set<Unit>().FirstOrDefault(u => u.Id == Unit3.Id);

            //Console.ReadLine();

            //context.Units.Remove(Unit3);
            //context.SaveChanges();

            //ReadUnit = context.Set<Unit>().FirstOrDefault(u => u.Id == Unit3.Id);

            //Console.ReadLine();
            #endregion

            #region InUse => WorkSession Test
            //Unit2.MarkAsInUse();
            //context.Units.Update(Unit2);
            //WorkSession WorkSession1 = Unit2.CurrentWorkSession;
            //context.WorkSessions.Add(WorkSession1);
            //context.SaveChanges();

            //Console.ReadLine();
            #endregion

            #region CRUD over Repositories (Unit, WorkSession)
            //UnitOfWork UnitOfWork1 = new UnitOfWork(context);
            //UnitRepository UnitRepository1 = new UnitRepository(context);

            //Unit? ReadUnit = UnitRepository1.GetUnitById(Unit3.Id);

            //Console.ReadLine();

            //Unit3.Description = "Maquina que hace tinta con alcohol";
            //UnitRepository1.UpdateUnit(Unit3);
            //UnitOfWork1.SaveChanges();

            //ReadUnit = UnitRepository1.GetUnitById(Unit3.Id);

            //Console.ReadLine();

            //UnitRepository1.DeleteUnit(Unit3);
            //UnitOfWork1.SaveChanges();

            //ReadUnit = UnitRepository1.GetUnitById(Unit3.Id);

            //Console.ReadLine();
            #endregion

            #region InUse => WorkSession over Repositories
            //UnitOfWork UnitOfWork1 = new UnitOfWork(context);
            //UnitRepository UnitRepository1 = new UnitRepository(context);
            //WorkSessionRepository WorkSessionRepository1 = new WorkSessionRepository(context);
            //UnitOfWork1.SaveChanges();

            //Unit? ReadUnit = UnitRepository1.GetUnitById(Unit2.Id);

            //Console.WriteLine(Object.ReferenceEquals(Unit2, ReadUnit));
            //Console.ReadLine();

            //Unit2.MarkAsInUse();
            //UnitRepository1.UpdateUnit(Unit2);
            //UnitOfWork1.SaveChanges();

            //ReadUnit = UnitRepository1.GetUnitById(Unit2.Id);
            //IEnumerable<WorkSession> ReadWorkSessions = WorkSessionRepository1.GetAllWorkSessions();

            //Console.ReadLine();

            //Unit2.MarkAsNotInUse();
            //UnitRepository1.UpdateUnit(Unit2);
            //UnitOfWork1.SaveChanges();

            //ReadUnit = UnitRepository1.GetUnitById(Unit2.Id);
            //ReadWorkSessions = WorkSessionRepository1.GetAllWorkSessions();

            #endregion

            #region CRUD over Repositories (Site, Area, WorkCenter)
            UnitOfWork UnitOfWork1 = new UnitOfWork(context);
            SiteRepository SiteRepository1 = new SiteRepository(context);
            AreaRepository AreaRepository1 = new AreaRepository(context);
            WorkCenterRepository WorkCenterRepository1 = new WorkCenterRepository(context);

            Site? ReadSite = SiteRepository1.GetSiteById(Site1.Id);
            Area? ReadArea = AreaRepository1.GetAreaById(Area2.Id);
            WorkCenter? ReadWorkCenter = WorkCenterRepository1.GetWorkCenterById(WorkCenter3.Id);

            Console.ReadLine();

            Site1.Location.City = "Ciudad Gotica";
            SiteRepository1.UpdateSite(Site1);
            Area2.Name = "Area de recreo";
            AreaRepository1.UpdateArea(Area2);
            WorkCenter3.Description = "Centro de Realidad Virtual";
            WorkCenterRepository1.UpdateWorkCenter(WorkCenter3);
            UnitOfWork1.SaveChanges();

            ReadSite = SiteRepository1.GetSiteById(Site1.Id);
            ReadArea = AreaRepository1.GetAreaById(Area2.Id);
            ReadWorkCenter = WorkCenterRepository1.GetWorkCenterById(WorkCenter3.Id);

            Console.ReadLine();

            SiteRepository1.DeleteSite(Site1);
            AreaRepository1.DeleteArea(Area2);
            WorkCenterRepository1.DeleteWorkCenter(WorkCenter3);
            UnitOfWork1.SaveChanges();

            ReadSite = SiteRepository1.GetSiteById(Site1.Id);
            ReadArea = AreaRepository1.GetAreaById(Area2.Id);
            ReadWorkCenter = WorkCenterRepository1.GetWorkCenterById(WorkCenter3.Id);

            Console.ReadLine();
            #endregion
        }

        private static object GetAllAreas(Empty empty)
        {
            throw new NotImplementedException();
        }
    }
}