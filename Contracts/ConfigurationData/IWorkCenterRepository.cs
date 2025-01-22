using ProductionStructure.Domain.Entity.ConfigurationData;

namespace ProductionStructure.Contracts.ConfigurationData
{
    public interface IWorkCenterRepository
    {
        void AddWorkCenter(WorkCenter workcenter);
        WorkCenter? GetWorkCenterById(Guid id);
        public IEnumerable<WorkCenter> GetAllWorkCenters();
        void UpdateWorkCenter(WorkCenter workcenter);
        void DeleteWorkCenter(WorkCenter workcenter);
    }
}