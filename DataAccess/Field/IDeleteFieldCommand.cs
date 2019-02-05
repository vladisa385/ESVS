using System;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Fields;

namespace DataAccess.Field
{
    public interface IDeleteFieldCommand
    {
        Task ExecuteAsync(Guid FieldId);
    }
}
