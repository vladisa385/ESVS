/*using System;
using System.Threading.Tasks;
using Entities;
using ViewModel;

namespace DataAccess.DbImplementation
{
    public class CatalogOfCatalogsQuery : ICatalogOfCatalogsQuery
    {
        private readonly CatalogOfCatalogsManager<CatalogOfCatalogs> _catalogofcatalogsManager;

        public CatalogOfCatalogsQuery(catalogOfCatalogsManager<CatalogOfCatalogs> catalogofcatalogsManager)
        {
            _catalogofcatalogsManager = catalogofcatalogsManager;
        }

        public async Task<CatalogOfCatalogsResponse> RunAsync(Guid catalogofcatalogsId)
        {

            CatalogOfCatalogsResponse response = await _catalogofcatalogsManager.CatalogOfCatalogs_s.Include("Recipies")
                .Include("Recipies")
                .Include("Reviews")
                .Include("CheapPlaces")
                .Include("RateReviews")
                .Include("RateCheapPlaces")
                .ProjectTo<CatalogOfCatalogsResponse>()
                .FirstOrDefaultAsync(p => p.Id == catalogofcatalogsId);
            return response;
        }
    }
}
*/