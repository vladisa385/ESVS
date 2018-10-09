using System;
using System.Threading.Tasks;
using ViewModel.Users;

namespace DataAccess.Users
{
    public interface IUserQuery
    {
        Task<UserResponse> RunAsync(Guid userId);
    }
}
