using System;
using System.Threading.Tasks;

namespace DataAccess.Catalog
{
    public interface IDeleteCatalogCommand
    {
        Task ExecuteAsync(Guid catalogId);
    }
}
