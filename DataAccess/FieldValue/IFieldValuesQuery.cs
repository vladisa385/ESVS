using System;
using System.Threading.Tasks;
using ViewModel.FieldValues;

namespace DataAccess.FieldValue
{
    public interface IFieldValuesQuery
    {
        Task<FieldValuesResponse> RunAsync(Guid fieldValueId);
    }
}
