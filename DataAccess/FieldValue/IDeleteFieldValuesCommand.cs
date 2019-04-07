using System;
using System.Threading.Tasks;

namespace DataAccess.FieldValue
{
    public interface IDeleteFieldValuesCommand
    {
        Task ExecuteAsync(Guid fieldValueId);
    }
}
