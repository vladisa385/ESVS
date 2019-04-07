using System.Threading.Tasks;
using ViewModel.FieldValues;

namespace DataAccess.FieldValue
{
    public interface ICreateFieldValueCommand
    {
        Task<FieldValueResponse> ExecuteAsync(CreateFieldValueRequest FieldValueName);
    }
}
