using System;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Fields;

namespace DataAccess.Field
{
    public interface IFieldQuery
    {
        Task<FieldResponse> RunAsync(Guid FieldId);
    }
}
