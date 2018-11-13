using System.Threading.Tasks;
using ViewModel;

namespace DataAccess
{
    public interface ICatalogOfCatalogsListQuery
    {
        Task<ListResponse<CatalogOfCatalogsResponse>> RunAsync(CatalogOfCatalogsFilter filter, ListOptions options);
    }
}
