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
        public DateTime InitDate { get; }
        public DateTime? EndDate { get; set; }
        #endregion

        #region Relational Properties
        /// <summary>
        /// Foreign Key to its related Unit
        /// </summary>
        public Guid UnitId { get; set; }
        public Unit Unit { get; }
        #endregion

        #region Constructors
        private WorkSession() : base() //Constructor without parameters, required by EF Core
        {
        }
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
