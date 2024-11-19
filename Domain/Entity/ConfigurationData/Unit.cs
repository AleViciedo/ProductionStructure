using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Domain.Entity.ConfigurationData
{
    public class Unit : Common.Entity
    {
        public string Name { get; set; }
        public string? Manufacturer { get; set; }
        public string? Description { get; set; }
        public Guid WorkCenter { get; set; }

        public Unit(Guid id, string name, Guid workCenter) : base (id)
        {
            Name = name;
            WorkCenter = workCenter;
        }

        public Unit(Guid id, string name, string? manufacturer, string? description, Guid workCenter) : base(id)
        {
            Name = name;
            Manufacturer = manufacturer;
            Description = description;
            WorkCenter = workCenter;
        }
    }
}
