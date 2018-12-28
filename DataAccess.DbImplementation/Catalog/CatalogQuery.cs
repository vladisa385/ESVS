using System;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using DataAccess.Roles;
using DB;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ViewModel.Roles;
using ViewModel;

namespace DataAccess.DbImplementation
{
    public class CatalogsQuery : ICatalogsQuery
    {
        private readonly AppDbContext _context;
        public CatalogsQuery(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<CatalogsResponse> RunAsync(Guid catalogofcatalogsId)
        {
            CatalogsResponse response = await _context.Catalogs
                .ProjectTo<CatalogsResponse>()
                .FirstOrDefaultAsync(p => p.Id == catalogofcatalogsId);
            return response;
        }
    }
}
