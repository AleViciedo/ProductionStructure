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
        public Guid Area { get; set; }
        public List<Unit> Units { get; set; }
        #endregion

        #region Constructors
        public WorkCenter(string name, Guid area) : base()
        {
            Name = name;
            Area = area;
            Units = new List<Unit>();
        }
        public WorkCenter(Guid id, string name, Guid area) : base (id)
        {
            Name = name;
            Area = area;
            Units = new List<Unit>();
        }
        public WorkCenter(string name, string? description, WorkMode workMode, Guid area, List<Unit> units) : base()
        {
            Name = name;
            Description = description;
            WorkMode = workMode;
            Area = area;
            Units = units;
        }
        public WorkCenter(Guid id, string name, string? description, WorkMode workMode, Guid area, List<Unit> units) : base(id)
        {
            Name = name;
            Description = description;
            WorkMode = workMode;
            Area = area;
            Units = units;
        }
        #endregion
    }
}
