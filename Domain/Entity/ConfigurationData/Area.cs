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
        #region Properties
        public string Name { get; set; }
        public Site Site { get; set; }
        public List<WorkCenter> WorkCenters { get; set; }
        #endregion

        #region Constructors
        public Area(string name, Site site) : base()
        {
            Name = name;
            WorkCenters = new List<WorkCenter>();
            Site = site;
        }
        public Area(Guid id, string name, Site site) : base(id)
        {
            Name = name;
            WorkCenters = new List<WorkCenter>();
            Site = site;
        }
        public Area(string name, Site site, List<WorkCenter> workCenters) : base()
        {
            Name = name;
            Site = site;
            WorkCenters = workCenters;
        }
        public Area(Guid id, string name, Site site, List<WorkCenter> workCenters) : base(id)
        {
            Name = name;
            Site = site;
            WorkCenters = workCenters;
        }
        #endregion
    }
}
