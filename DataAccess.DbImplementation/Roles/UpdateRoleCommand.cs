using System;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Roles;
using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ViewModel.Roles;

namespace DataAccess.DbImplementation.Roles
{
    public class UpdateRoleCommand : IUpdateRoleCommand
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;
        public UpdateRoleCommand(RoleManager<Role> roleManager,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IHostingEnvironment appEnvironment)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;

            _appEnvironment = appEnvironment;
        }
        public async Task<RoleResponse> ExecuteAsync(UpdateRoleRequest request)
        {
            var foundRole = await _roleManager.FindByIdAsync(request.Id.ToString());
            if (foundRole == null) return null;

            foundRole.Name = request.Name;
            foundRole.RoleDescription = request.RoleDescription;

            await _roleManager.UpdateAsync(foundRole);

            return _mapper.Map<Role, RoleResponse>(foundRole);
        }
    }
}
