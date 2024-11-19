using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Domain.Entity.HistoricalData
{
    public class WorkSession : Common.Entity
    {
        public Guid Unit { get; }
        public DateTime InitDate { get; }
        public DateTime EndDate { get; set; }

        public WorkSession(Guid id, Guid unit) : base (id)
        {
            Unit = unit;
            InitDate = DateTime.Now;
        }
    }
}
