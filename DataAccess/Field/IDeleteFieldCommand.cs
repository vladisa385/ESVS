using System;
using System.Threading.Tasks;

namespace DataAccess.Field
{
    public interface IDeleteFieldCommand
    {
        Task ExecuteAsync(Guid FieldId);
    }
}
