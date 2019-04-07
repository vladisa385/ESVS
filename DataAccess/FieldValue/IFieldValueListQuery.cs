using System.Threading.Tasks;
using ViewModel;
using ViewModel.FieldValues;

namespace DataAccess.FieldValue
{
    public interface IFieldValueListQuery
    {
        Task<ListResponse<FieldValueResponse>> RunAsync(FieldValueFilter filter, ListOptions options);
    }
}
