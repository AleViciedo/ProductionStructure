using ProductionStructure.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Domain.Entity.ConfigurationData
{
    public class WorkCenter : Common.Entity
    {
        #region Properties
        public string Name { get; set; }
        public string? Description { get; set; }
        public WorkMode WorkMode { get; set; }
        public List<Unit> Units { get; set; }
        #endregion

        #region Relational Properties
        /// <summary>
        /// Foreign Key to its related Area
        /// </summary>
        public Guid AreaId { get; set; }
        public Area Area { get; set; }
        #endregion

        #region Constructors
        private WorkCenter() : base() //Constructor without parameters, required by EF Core
        {
        }
        public WorkCenter(string name, Area area) : base() //basic
        {
            Name = name;
            Area = area;
            Units = new List<Unit>();
            AreaId = Area.Id;
        }
        public WorkCenter(Guid id, string name, Area area) : base (id) //basic with ID
        {
            Name = name;
            Area = area;
            Units = new List<Unit>();
            AreaId = Area.Id;
        }
        public WorkCenter(string name, string? description, WorkMode workMode, Area area, List<Unit> units) : base() //full
        {
            Name = name;
            Description = description;
            WorkMode = workMode;
            Area = area;
            Units = units;
            AreaId = Area.Id;
        }
        public WorkCenter(Guid id, string name, string? description, WorkMode workMode, Area area, List<Unit> units) : base(id) //full with ID
        {
            Name = name;
            Description = description;
            WorkMode = workMode;
            Area = area;
            Units = units;
            AreaId = Area.Id;
        }
        #endregion
    }
}
