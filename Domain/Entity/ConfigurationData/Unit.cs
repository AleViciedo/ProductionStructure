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
        public WorkCenter WorkCenter { get; set; }
        public WorkSession? WorkSession { get; set; }
        public bool InUse
        {
            get
            {
                return WorkSession != null;
            }
            set
            {
                if (WorkSession != null && value == false)
                {
                    WorkSession = null;
                }
                else if (WorkSession == null && value == true)
                {
                    WorkSession = new WorkSession(this);
                }
            }
        }
        #endregion

        #region Constructors
        public Unit(string name, WorkCenter workCenter) : base() //basic
        {
            Name = name;
            WorkCenter = workCenter;
        }
        public Unit(Guid id, string name, WorkCenter workCenter) : base (id) //basic with ID
        {
            Name = name;
            WorkCenter = workCenter;
        }
        public Unit(string name, string? manufacturer, string? description, WorkCenter workCenter, WorkSession? workSession) : base() //full
        {
            Name = name;
            Manufacturer = manufacturer;
            Description = description;
            WorkCenter = workCenter;
            WorkSession = workSession;
        }
        public Unit(Guid id, string name, string? manufacturer, string? description, WorkCenter workCenter, WorkSession? workSession) : base(id) //full with ID
        {
            Name = name;
            Manufacturer = manufacturer;
            Description = description;
            WorkCenter = workCenter;
            WorkSession = workSession;
        }
        #endregion

        #region Methods
       
        #endregion
    }
}
