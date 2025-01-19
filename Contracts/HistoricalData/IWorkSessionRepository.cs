using ProductionStructure.Domain.Entity.ConfigurationData;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.Contracts.HistoricalData
{
    public interface IWorkSessionRepository
    {
        void AddWorkSession(WorkSession workSession);

        WorkSession? GetWorkSessionById(Guid id);

        public IEnumerable<WorkSession> GetAllWorkSessions();

        void UpdateWorkSession(WorkSession workSession);

        void DeleteWorkSession(WorkSession workSession);
    }
}
