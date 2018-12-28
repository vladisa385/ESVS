using System;
using System.Threading.Tasks;
using ViewModel;

namespace DataAccess
{
    public interface IUpdateCatalogsCommand
    {
        Task<CatalogsResponse> ExecuteAsync(Guid catalogofcatalogsId, UpdateCatalogsRequest request);
    }
}
