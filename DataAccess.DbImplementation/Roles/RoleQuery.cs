using System;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using DataAccess.Roles;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ViewModel.Roles;

namespace DataAccess.DbImplementation.Roles
{
    public class RoleQuery : IRoleQuery
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleQuery(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<RoleResponse> RunAsync(Guid roleId)
        {

            RoleResponse response = await _roleManager.Roles.Include("Recipies")
                .Include("Recipies")
                .Include("Reviews")
                .Include("CheapPlaces")
                .Include("RateReviews")
                .Include("RateCheapPlaces")
                .ProjectTo<RoleResponse>()
                .FirstOrDefaultAsync(p => p.Id == roleId);
            return response;
        }
    }
}
