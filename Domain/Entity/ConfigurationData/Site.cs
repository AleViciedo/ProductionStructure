using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductionStructure.Domain.Common;
using ProductionStructure.Domain.ValueObjects;

namespace ProductionStructure.Domain.Entity.ConfigurationData
{
    public class Site : Common.Entity
    {
        #region Properties
        public string Name { get; set; }
        public Location Location { get; set; }
        public Email? Email { get; set; }
        public PhoneNumber? PhoneNumber { get; set; }
        public List<Area> Areas { get; set; }
        #endregion

        #region Constructors
        public Site(string name, Location location) : base()
        {
            Name = name;
            Location = location;
            Areas = new List<Area>();
        }
        public Site(Guid id, string name, Location location) : base (id)
        {
            Name = name;
            Location = location;
            Areas = new List<Area>();
        }
        public Site(string name, Location location, Email? email, PhoneNumber? phoneNumber, List<Area> areas) : base()
        {
            Name = name;
            Location = location;
            Email = email;
            PhoneNumber = phoneNumber;
            Areas = areas;
        }
        public Site(Guid id, string name, Location location, Email? email, PhoneNumber? phoneNumber, List<Area> areas) : base(id)
        {
            Name = name;
            Location = location;
            Email = email;
            PhoneNumber = phoneNumber;
            Areas = areas;
        }
        #endregion
    }
}
