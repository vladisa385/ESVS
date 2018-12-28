using System;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Roles;
using DB;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ViewModel.Roles;

namespace DataAccess.DbImplementation.Roles
{
    public class AddRoleToUserCommand : IAddRoleToUserCommand
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public AddRoleToUserCommand(AppDbContext context, IMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<RoleResponse> ExecuteAsync(Guid roleId, Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return null;
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role == null) return null;
            IdentityResult result = await _userManager.AddToRoleAsync(user, role.Name);
            return result.Succeeded ? _mapper.Map<Role, RoleResponse>(role) : null;
        }
    }
}
