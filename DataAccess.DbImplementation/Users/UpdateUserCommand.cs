using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Users;
using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ViewModel.Users;

namespace DataAccess.DbImplementation.Users
{
    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;
        public UpdateUserCommand(UserManager<User> userManager,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IHostingEnvironment appEnvironment)
        {
            _userManager = userManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;

            _appEnvironment = appEnvironment;
        }
        public async Task<UserResponse> ExecuteAsync(UpdateUserRequest request)
        {


            var foundUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

           
            foundUser.FirstName = request.FirstName;
            foundUser.LastName = request.LastName;
            foundUser.Gender = request.Gender;
            //if (request.Avatar != null)
            //{
            //    string basedir = _appEnvironment.WebRootPath + "/Users/";
            //    foundUser.PathToAvatar = basedir + request.Avatar.FileName;
            //    await CreateFileCommand.ExecuteAsync(request.Avatar, basedir);
            //}

            await _userManager.UpdateAsync(foundUser);

            return _mapper.Map<User, UserResponse>(foundUser);

        }
    }
}
