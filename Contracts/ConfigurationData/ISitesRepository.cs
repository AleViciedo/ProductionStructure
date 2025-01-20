using ProductionStructure.Domain.Entity.ConfigurationData;

namespace ProductionStructure.Contracts.ConfigurationData
{
    public interface ISitesRepository
    {
        void AddSite(Site site);

        Site? GetSiteById(Guid id);

        public IEnumerable<Site> GetAllSites();

        void UpdateSite(Site site);

        void DeleteSite(Site site);

    }
}