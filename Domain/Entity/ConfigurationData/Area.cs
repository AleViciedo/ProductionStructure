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
        public List<WorkCenter> WorkCenters { get; set; }
        #endregion

        #region Relational Properties
        /// <summary>
        /// Foreign Key to its related Site
        /// </summary>
        public Guid SiteId { get; set; }
        public Site Site { get; set; }
        #endregion

        #region Constructors
        public Area(string name, Site site) : base() //basic
        {
            Name = name;
            WorkCenters = new List<WorkCenter>();
            Site = site;
            SiteId = Site.Id;
        }
        public Area(Guid id, string name, Site site) : base(id) //basic with ID
        {
            Name = name;
            WorkCenters = new List<WorkCenter>();
            Site = site;
            SiteId = Site.Id;
        }
        public Area(string name, Site site, List<WorkCenter> workCenters) : base() //full
        {
            Name = name;
            Site = site;
            WorkCenters = workCenters;
            SiteId = Site.Id;
        }
        public Area(Guid id, string name, Site site, List<WorkCenter> workCenters) : base(id) //full with ID
        {
            Name = name;
            Site = site;
            WorkCenters = workCenters;
            SiteId = Site.Id;
        }
        #endregion
    }
}
