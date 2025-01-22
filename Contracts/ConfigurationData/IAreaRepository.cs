using ProductionStructure.Domain.Entity.ConfigurationData;

namespace ProductionStructure.Contracts.ConfigurationData
{
    public interface IAreaRepository
    {
        void AddArea(Area area);
        Area? GetAreaById(Guid id);
        public IEnumerable<Area> GetAllAreas();
        void UpdateArea(Area area);
        void DeleteArea(Area area);
    }
}