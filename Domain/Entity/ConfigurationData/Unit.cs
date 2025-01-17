using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Domain.Entity.ConfigurationData
{
    public class Unit : Common.Entity
    {
        #region Properties
        public string Name { get; set; }
        public string? Manufacturer { get; set; }
        public string? Description { get; set; }
        public Guid WorkCenter { get; set; }
        public bool InUse { get; private set; }
        #endregion

        #region Constructors
        public Unit(string name, Guid workCenter) : base()
        {
            Name = name;
            WorkCenter = workCenter;
        }
        public Unit(Guid id, string name, Guid workCenter) : base (id)
        {
            Name = name;
            WorkCenter = workCenter;
        }
        public Unit(string name, string? manufacturer, string? description, Guid workCenter) : base()
        {
            Name = name;
            Manufacturer = manufacturer;
            Description = description;
            WorkCenter = workCenter;
        }
        public Unit(Guid id, string name, string? manufacturer, string? description, Guid workCenter) : base(id)
        {
            Name = name;
            Manufacturer = manufacturer;
            Description = description;
            WorkCenter = workCenter;
        }
        #endregion

        #region Methods
        public WorkSession StartProcess()
        {
            InUse = true;
            return new WorkSession(this.Id);
        }

        public bool EndProcess(WorkSession workSession)
        {
            if (workSession.Unit != this.Id)
                return false;
            workSession.EndDate = DateTime.Now;
            InUse = false;
            return true;
        }
        #endregion
    }
}
