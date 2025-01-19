using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Domain.ValueObjects
{
    public class PhoneNumber
    {
        public string Country { get; set; }
        public string Phone { get; set; }

        public PhoneNumber(string country, string phone)
        {
            Country = country;
            Phone = phone;
        }

        public PhoneNumber(string phone)
        {
            string[] input = phone.Split(' ');
            if (input.Length == 1)
            {
                Phone = input[0];
            }
            else if (input.Length == 2)
            {
                Country = input[0];
                Phone = input[1];
            }
            else
                throw new ArgumentException("Invalid Phone format");
        }

        public override string ToString()
        {
            return string.Join(" ", "+" + Country, Phone);
        }
    }
}
