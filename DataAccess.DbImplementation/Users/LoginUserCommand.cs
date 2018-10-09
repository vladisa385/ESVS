using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Users;
using Entities;
using Microsoft.AspNetCore.Identity;
using ViewModel.Users;

namespace DataAccess.DbImplementation.Users
{
    public class LoginUserCommand : ILoginUserCommand
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public LoginUserCommand(SignInManager<User> signInManager, UserManager<User> userManager, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserResponse> ExecuteAsync(LoginUserRequest request)
        {
            var result =
                await _signInManager.PasswordSignInAsync(request.Email, request.Password, request.RememberMe, false);
            if (!result.Succeeded)
            {
                throw new IncorrectPasswordOrEmailExeption();
            }

            var user = await _userManager.FindByEmailAsync(request.Email);
            return _mapper.Map<User, UserResponse>(user);


        }
    }
}
