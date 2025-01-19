using System;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using DataAccess.Context;
using ProductionStructure.Domain.Entity.ConfigurationData;
using ProductionStructure.Domain.ValueObjects;
using ProductionStructure.Domain.Entity.HistoricalData;

namespace ProductionStructure.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationContext context = new ApplicationContext("Data Source=ProductionStructureDB.sqlite");
            if (!context.Database.CanConnect())
                context.Database.Migrate();
            Location Location1 = new Location(new CountryData.Standard.Country(), "Ciudad de las risas", "Calle 48 #4893 % C y D");
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
        }
    }
}