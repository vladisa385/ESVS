using System.Threading.Tasks;
using ViewModel.Users;

namespace DataAccess.Users
{
    public interface IUpdateUserCommand
    {

        Task<UserResponse> ExecuteAsync(UpdateUserRequest request);

    }
}
