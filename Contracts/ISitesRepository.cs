using ProductionStructure.Domain.Entity.ConfigurationData;

namespace Contracts
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