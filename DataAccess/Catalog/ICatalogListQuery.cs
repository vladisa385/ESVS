using System.Threading.Tasks;
using ViewModel;

namespace DataAccess
{
    public interface ICatalogsListQuery
    {
        Task<ListResponse<CatalogsResponse>> RunAsync(CatalogsFilter filter, ListOptions options);
    }
}
