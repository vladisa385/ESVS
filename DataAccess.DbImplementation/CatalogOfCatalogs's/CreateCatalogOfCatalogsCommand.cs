/*using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Roles;
using DataAccess.Users;
using Entities;
using Microsoft.AspNetCore.Identity;
using ViewModel.Roles;
using ViewModel;

namespace DataAccess.DbImplementation
{
    public class CreateCatalogOfCatalogsCommand : ICreateCatalogOfCatalogsCommand
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        public CreateRoleCommand(
            RoleManager<Role> roleManager,
            IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<RoleResponse> ExecuteAsync(CreateRoleRequest request)
        {
            Role role = new Role
            {
                Name = request.Name,
                RoleDescription = request.RoleDescription,


            };

            // добавляем пользователя

            var result = await _roleManager.CreateAsync(role);
            // установка куки
            if (!result.Succeeded)
                throw new CannotCreateUserExeption(result.Errors);

            return _mapper.Map<Role, RoleResponse>(role);

        }
    }
}*/
