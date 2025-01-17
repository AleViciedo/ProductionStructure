using ProductionStructure.Domain.Entity.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Domain.Entity.HistoricalData
{
    public class WorkSession : Common.Entity
    {
        #region Properties
        public Unit Unit { get; }
        public DateTime InitDate { get; }
        public DateTime? EndDate { get; set; }
        #endregion

        #region Constructors
        public WorkSession(Guid id, Unit unit) : base (id)
        {
            Unit = unit;
            InitDate = DateTime.Now;
        }
        public WorkSession(Unit unit) : base()
        {
            Unit = unit;
            InitDate = DateTime.Now;
        }

        public WorkSession(Unit unit, DateTime initDate) : base()
        {
            InitDate = initDate;
            Unit = unit;
            InitDate = DateTime.Now;
        }
        public WorkSession(Guid id, Unit unit, DateTime initDate) : base(id)
        {
            InitDate = initDate;
            Unit = unit;
            InitDate = DateTime.Now;
        }
        public WorkSession(Unit unit, DateTime initDate, DateTime endDate) : base()
        {
            InitDate = initDate;
            EndDate = endDate;
            Unit = unit;
            InitDate = DateTime.Now;
        }
        public WorkSession(Guid id, Unit unit, DateTime initDate, DateTime endDate) : base(id)
        {
            InitDate = initDate;
            EndDate = endDate;
            Unit = unit;
            InitDate = DateTime.Now;
        }
        #endregion
    }
}
