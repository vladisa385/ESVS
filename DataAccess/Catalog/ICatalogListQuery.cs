using System.Threading.Tasks;
using ViewModel;
using ViewModel.Catalogs;

namespace DataAccess.Catalog
{
    public interface ICatalogListQuery
    {
        Task<ListResponse<CatalogResponse>> RunAsync(CatalogFilter filter, ListOptions options);
    }
}
