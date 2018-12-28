using System.Threading.Tasks;
using ViewModel;

namespace DataAccess
{
    public interface ICreateCatalogsCommand
    {
        Task<CatalogsResponse> ExecuteAsync(CreateCatalogsRequest catalogofcatalogsName);
    }
}
