using System;
using System.Threading.Tasks;
using ViewModel.Fields;

namespace DataAccess.Field
{
    public interface IUpdateFieldCommand
    {
        Task<FieldResponse> ExecuteAsync(Guid fieldId, UpdateFieldRequest request);
    }
}
