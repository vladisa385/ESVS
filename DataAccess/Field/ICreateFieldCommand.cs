using System;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Fields;

namespace DataAccess.Field
{
    public interface ICreateFieldCommand
    {
        Task<FieldResponse> ExecuteAsync(CreateFieldRequest FieldName);
    }
}
