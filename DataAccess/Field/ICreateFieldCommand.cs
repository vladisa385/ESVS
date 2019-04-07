using System.Threading.Tasks;
using ViewModel.Fields;

namespace DataAccess.Field
{
    public interface ICreateFieldCommand
    {
        Task<FieldResponse> ExecuteAsync(CreateFieldRequest fieldName);
    }
}
