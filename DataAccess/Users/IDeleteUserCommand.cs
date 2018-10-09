using System;
using System.Threading.Tasks;

namespace DataAccess.Users
{
    public interface IDeleteUserCommand
    {
        Task ExecuteAsync(Guid userId);
    }
}
