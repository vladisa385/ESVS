using System.Threading.Tasks;
using ViewModel;
using ViewModel.FieldValues;

namespace DataAccess.FieldValue
{
    public interface IFieldValuesListQuery
    {
        Task<ListResponse<FieldValuesResponse>> RunAsync(FieldValuesFilter filter, ListOptions options);
    }
}
