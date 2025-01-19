using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Domain.ValueObjects
{
    public class Email
    {
        public string Username { get; set; }
        public string Server { get; set; }

        public Email(string username, string server)
        {
            Username = username;
            Server = server;
        }

        public override string ToString()
        {
            return string.Join("@", Username, Server);
        }
    }
}
