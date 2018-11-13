using System;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDeleteCatalogOfCatalogsCommand
    {
        Task ExecuteAsync(Guid catalogofcatalogsId);
    }
}
