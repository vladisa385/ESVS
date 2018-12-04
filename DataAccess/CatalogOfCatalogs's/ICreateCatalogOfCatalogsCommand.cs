using System.Threading.Tasks;
using ViewModel;

namespace DataAccess
{
    public interface ICreateCatalogOfCatalogsCommand
    {
        Task<CatalogOfCatalogsResponse> ExecuteAsync(CreateCatalogOfCatalogsRequest catalogofcatalogsName);
    }
}
