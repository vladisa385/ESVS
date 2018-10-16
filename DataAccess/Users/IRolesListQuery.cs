using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Users;

namespace DataAccess.Users
{
    public interface IRolesListQuery
    {
        Task<ListResponse<RoleResponse>> RunAsync(RoleFilter filter, ListOptions options);

    }
}
