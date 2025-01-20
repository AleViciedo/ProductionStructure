using Contracts;
using DataAccess.Context;
using ProductionStructure.Contracts.HistoricalData;
using ProductionStructure.DataAccess.Repositories.Common;
using ProductionStructure.Domain.Entity.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionStructure.DataAccess.Repositories.HistoricalData
{
    public class WorkSessionRepository
        : RepositoryBase, IWorkSessionRepository
    {
        public WorkSessionRepository(ApplicationContext context) : base(context)
        {
        }

        public void AddWorkSession(WorkSession workSession)
        {
            _context.WorkSessions.Add(workSession);
        }

        public WorkSession? GetWorkSessionById(Guid id)
        {
            return _context.WorkSessions.FirstOrDefault(ws => ws.Id == id);
        }

        public IEnumerable<WorkSession> GetAllWorkSessions()
        {
            return _context.WorkSessions.ToList();
        }

        public void UpdateWorkSession(WorkSession workSession)
        {
            _context.WorkSessions.Update(workSession);
        }

        public void DeleteWorkSession(WorkSession workSession)
        {
            _context.WorkSessions.Remove(workSession);
        }
    }
}
