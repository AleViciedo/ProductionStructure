﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataacces.Utilities
{
    public static class ConnectionStringProvider
    {
        public static string GetConnectionString() => "Data Source=Data.sqlite";
    }
}
