using System.Threading.Tasks;
using ViewModel.Users;

namespace DataAccess.Users
{
    public interface IChangeUserPasswordCommand
    {
        Task<UserResponse> ExecuteAsync(ChangePasswordUserRequest request);
    }
}
