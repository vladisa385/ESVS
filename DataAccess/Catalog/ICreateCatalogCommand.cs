using System.Threading.Tasks;
using ViewModel.Catalogs;

namespace DataAccess.Catalog
{
    public interface ICreateCatalogCommand
    {
        Task<CatalogResponse> ExecuteAsync(CreateCatalogRequest catalogName);
    }
}
