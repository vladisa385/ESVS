using System.Threading.Tasks;
using ViewModel;
using ViewModel.Users;

namespace DataAccess.Users
{
    public interface IUsersListQuery
    {
        Task<ListResponse<UserResponse>> RunAsync(UserFilter filter, ListOptions options);
    }
}
