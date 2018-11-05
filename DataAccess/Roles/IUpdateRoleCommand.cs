using System.Threading.Tasks;
using ViewModel.Users;

namespace DataAccess.Users
{
    public interface IUpdateRoleCommand
    {
        Task<RoleResponse> ExecuteAsync(UpdateRoleRequest request);
    }
}
