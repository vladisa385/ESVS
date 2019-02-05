using System;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Fields;

namespace DataAccess.Field
{
    public interface IUpdateFieldCommand
    {
        Task<FieldResponse> ExecuteAsync(Guid FieldId, UpdateFieldRequest request);
    }
}
