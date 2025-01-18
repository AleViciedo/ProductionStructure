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
            Unit Unit1 = new Unit("Maquina de hacer papel", "Maquinadores3000", WorkCenter1,null,new List<WorkSession>());
            Unit Unit2 = new Unit("Maquina de hacer hilo", "Maquinadores3000", WorkCenter1, null, new List<WorkSession>());
            Unit Unit3 = new Unit("Maquina de hacer tinta", WorkCenter2);
            Unit Unit4 = new Unit("Maquina de hacer plastico", WorkCenter2);
            Unit Unit5 = new Unit("Impresora Industrial", WorkCenter3);
            Unit Unit6 = new Unit("Maquina de corte, ajusto y control", WorkCenter3);
            Unit Unit7 = new Unit("Encuadernadora", WorkCenter4);
            Unit Unit8 = new Unit("Estacion de personalizacion", WorkCenter4);
        }
    }
}