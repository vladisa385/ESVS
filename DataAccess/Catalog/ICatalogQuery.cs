using System;
using System.Threading.Tasks;
using ViewModel;

namespace DataAccess
{
    public interface ICatalogsQuery
    {
        Task<CatalogsResponse> RunAsync(Guid catalogofcatalogsId);
    }
}
