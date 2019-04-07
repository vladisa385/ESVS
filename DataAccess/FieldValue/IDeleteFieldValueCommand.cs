using System;
using System.Threading.Tasks;

namespace DataAccess.FieldValue
{
    public interface IDeleteFieldValueCommand
    {
        Task ExecuteAsync(Guid FieldValueId);
    }
}
