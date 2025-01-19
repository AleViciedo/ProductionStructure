using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountryData.Standard;

namespace ProductionStructure.Domain.ValueObjects
{
    public class Location
    {
        public Country Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        private Location() //Constructor without parameters, required by EF Core
        {
        }
        public Location(Country country, string city, string address)
        {
            Country = country;
            City = city;
            Address = address;
        }
    }
}
