using System;
using System.Threading.Tasks;
using ViewModel.FieldValues;

namespace DataAccess.FieldValue
{
    public interface IUpdateFieldValueCommand
    {
        Task<FieldValueResponse> ExecuteAsync(Guid FieldValueId, UpdateFieldValueRequest request);
    }
}
