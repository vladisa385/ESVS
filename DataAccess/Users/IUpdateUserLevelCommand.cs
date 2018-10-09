using System.Threading.Tasks;
using ViewModel.Users;

namespace DataAccess.Users
{
    public interface IUpdateUserLevelCommand
    {
        Task<UserResponse> ExecuteAsync(string userId);
    }
}
