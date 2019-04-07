using System;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Catalogs;

namespace DataAccess.Catalog
{
    public interface IUpdateCatalogCommand
    {
        Task<CatalogResponse> ExecuteAsync(Guid catalogId, UpdateCatalogRequest request);
    }
}
