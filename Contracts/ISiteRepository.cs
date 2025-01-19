namespace Contracts
{
    public interface ISitesRepository
    {
        /// <param name="site"></param>
        void AddSite(Site site);

        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetAllSite<T>() where T : Site;

        /// <param name="site"></param>
        void UpdateSite(Site site);

         /// <param name="site"></param>
        void DeleteSite(Site site);

    }
}