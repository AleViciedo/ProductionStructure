using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using ProductionStructure.DataAccess.Repositories.Common;
using ProductionStructure.Domain.Entity.ConfigurationData;
using ProductionStructure.Contracts.ConfigurationData;
using ProductionStructure.DataAccess.Context;

namespace ProductionStructure.DataAccess.Repositories.ConfigurationData
{
    public class WorkCenterRepository
        : RepositoryBase, IWorkCenterRepository
    {
        public WorkCenterRepository(ApplicationContext context) : base(context)
        {
        }

        public void AddWorkCenter(WorkCenter workcenter)
        {
            _context.WorkCenters.Add(workcenter);
        }

        public void DeleteWorkCenter (WorkCenter workcenter)
        {
            _context.WorkCenters.Remove(workcenter);
        }

        public WorkCenter GetWorkCenterById(Guid id)
        {
            return _context.WorkCenters.FirstOrDefault(wc => wc.Id == id);
        }

        public IEnumerable<WorkCenter> GetAllWorkCenters()
        {
            return _context.WorkCenters.ToList();
        }

        public void UpdateWorkCenter(WorkCenter workcenter)
        {
            _context.WorkCenters.Update(workcenter);
        }
    }
}