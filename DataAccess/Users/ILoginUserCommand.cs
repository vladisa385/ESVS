using System.Threading.Tasks;
using ViewModel.Users;

namespace DataAccess.Users
{
    public interface ILoginUserCommand
    {
        Task<UserResponse> ExecuteAsync(LoginUserRequest request);
    }
}
