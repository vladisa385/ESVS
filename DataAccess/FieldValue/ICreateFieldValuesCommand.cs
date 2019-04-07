using System.Threading.Tasks;
using ViewModel.FieldValues;

namespace DataAccess.FieldValue
{
    public interface ICreateFieldValuesCommand
    {
        Task<FieldValuesResponse> ExecuteAsync(CreateFieldValuesRequest fieldValueName);
    }
}
