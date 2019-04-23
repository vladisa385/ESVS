using System.Threading.Tasks;
using ViewModel;
using ViewModel.Fields;

namespace DataAccess.Field
{
    public interface IFieldListQuery
    {
        Task<ListResponse<FieldResponse>> RunAsync(FieldFilter filter, ListOptions options);
    }
}
