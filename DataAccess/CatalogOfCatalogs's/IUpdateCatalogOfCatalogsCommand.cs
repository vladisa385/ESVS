using System;
using System.Threading.Tasks;
using ViewModel;

namespace DataAccess
{
    public interface IUpdateCatalogOfCatalogsCommand
    {
        Task<CatalogOfCatalogsResponse> ExecuteAsync(Guid catalogofcatalogsId, UpdateCatalogOfCatalogsRequest request);
    }
}
