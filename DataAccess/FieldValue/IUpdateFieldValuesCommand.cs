using System;
using System.Threading.Tasks;
using ViewModel.FieldValues;

namespace DataAccess.FieldValue
{
    public interface IUpdateFieldValuesCommand
    {
        Task<FieldValuesResponse> ExecuteAsync(Guid fieldValueId, UpdateFieldValuesRequest request);
    }
}
