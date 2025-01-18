using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Domain.Entity.ConfigurationData
{
    public class Unit : Common.Entity
    {
        #region Properties
        public string Name { get; set; }
        public string? Manufacturer { get; set; }
        public string? Description { get; set; }
        public WorkSession? CurrentWorkSession { get; set; } //funcionara como un puntero a la ultima WorkSession de la List<WorkSession>
        public List<WorkSession> WorkSessions { get; set; }
        public bool InUse => CurrentWorkSession != null;
        #endregion

        #region Relational Properties
        public Guid? CurrentWorkSessionId { get; set; } //Id for foreign key to use in EF Core relationship
        /// <summary>
        /// Foreign Key to its related WorkCenter
        /// </summary>
        public Guid WorkCenterId { get; set; }
        public WorkCenter WorkCenter { get; set; }
        #endregion

        #region Constructors
        private Unit() : base() //Constructor without parameters, required by EF Core
        {
        }
        public Unit(string name, WorkCenter workCenter) : base() //basic
        {
            Name = name;
            WorkCenter = workCenter;
            WorkCenterId = WorkCenter.Id;
        }
        public Unit(Guid id, string name, WorkCenter workCenter) : base (id) //basic with ID
        {
            Name = name;
            WorkCenter = workCenter;
            WorkCenterId = WorkCenter.Id;
        }
        public Unit(string name, string? manufacturer, string? description, WorkCenter workCenter, WorkSession? currentWorkSession, List<WorkSession> workSessions) : base() //full
        {
            Name = name;
            Manufacturer = manufacturer;
            Description = description;
            WorkCenter = workCenter;
            CurrentWorkSession = currentWorkSession;
            CurrentWorkSessionId = CurrentWorkSession.Id;
            WorkCenterId = WorkCenter.Id;
            WorkSessions = workSessions;
        }
        public Unit(Guid id, string name, string? manufacturer, string? description, WorkCenter workCenter, WorkSession? currentWorkSession, List<WorkSession> workSessions) : base(id) //full with ID
        {
            Name = name;
            Manufacturer = manufacturer;
            Description = description;
            WorkCenter = workCenter;
            CurrentWorkSession = currentWorkSession;
            CurrentWorkSessionId = CurrentWorkSession.Id;
            WorkCenterId = WorkCenter.Id;
            WorkSessions = workSessions;
        }
        #endregion

        #region Methods
        public void MarkAsInUse()
        {
            if (CurrentWorkSession == null)
            {
                var newSession = new WorkSession(this); //crea una variable separada en memoria de CurrentWorkSession que pasar por referencia a la List<WorkSession>
                CurrentWorkSession = newSession;
                if(!WorkSessions.Contains(newSession))
                    WorkSessions.Add(newSession);
            }
        }

        public void MarkAsNotInUse()
        {
            if (CurrentWorkSession != null)
            {
                CurrentWorkSession.EndDate = DateTime.Now; //actualiza la variable, a la que tambien se apunta desde una posicion de la List<WorkSession>
                CurrentWorkSession = null;
            }
        }
        #endregion
    }
}
