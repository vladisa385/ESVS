using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Users;
using DB;
using Entities;
using Microsoft.AspNetCore.Identity;
using ViewModel.Users;

namespace DataAccess.DbImplementation.Users
{
    public class CreateRoleCommand : ICreateRoleCommand
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<Role> _signInManager;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public CreateRoleCommand(
            RoleManager<Role> roleManager,
            SignInManager<Role> signInManager,
            IMapper mapper, AppDbContext context)
        {
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _context = context;
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

            await _signInManager.SignInAsync(role, false);

            return _mapper.Map<Role, RoleResponse>(role);

        }
    }
}
