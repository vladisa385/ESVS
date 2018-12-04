using System;
using System.Threading.Tasks;
using ViewModel;

namespace DataAccess
{
    public interface ICatalogOfCatalogsQuery
    {
        Task<CatalogOfCatalogsResponse> RunAsync(Guid catalogofcatalogsId);
    }
}
