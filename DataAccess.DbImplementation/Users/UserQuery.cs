using System;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using DataAccess.Users;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ViewModel.Users;

namespace DataAccess.DbImplementation.Users
{
    public class UserQuery : IUserQuery
    {
        private readonly UserManager<User> _userManager;

        public UserQuery(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserResponse> RunAsync(Guid userId)
        {

            UserResponse response = await _userManager.Users.Include("Recipies")
                 .Include("Recipies")
                .Include("Reviews")
                .Include("CheapPlaces")
                .Include("RateReviews")
                 .Include("RateCheapPlaces")
                .ProjectTo<UserResponse>()
                .FirstOrDefaultAsync(p => p.Id == userId);
            return response;
        }
    }
}
