using System.Threading.Tasks;
using ViewModel;
using ViewModel.Roles;
using ViewModel.Users;

namespace DataAccess.Roles
{
    public interface IRolesListQuery
    {
        Task<ListResponse<RoleResponse>> RunAsync(RoleFilter filter, ListOptions options);

    }
}
