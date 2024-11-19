using ProductionStructure.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Domain.Entity.ConfigurationData
{
    public class Area : Common.Entity
    {
        public string Name { get; set; }
        public Guid Site { get; set; }
        public List<WorkCenter> WorkCenters { get; set; }

        public Area(Guid id, string name, Guid site) : base(id)
        {
            Name = name;
            WorkCenters = new List<WorkCenter>();
            Site = site;
        }

        public Area(Guid id, string name, Guid site, List<WorkCenter> workCenters) : base(id)
        {
            Name = name;
            Site = site;
            WorkCenters = workCenters;
        }
    }
}
