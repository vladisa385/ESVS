using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Users;
using Entities;
using Microsoft.AspNetCore.Identity;
using ViewModel.Users;

namespace DataAccess.DbImplementation.Users
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public CreateUserCommand(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }
        public async Task<UserResponse> ExecuteAsync(CreateUserRequest request)
        {
            User user = new User
            {
                Email = request.Email,
                UserName = request.Email,
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                throw new UserCredentialsException(result.Errors);
            await _signInManager.SignInAsync(user, false);
            await _userManager.AddToRoleAsync(user, "user");
            return _mapper.Map<User, UserResponse>(user);
        }
    }
}
