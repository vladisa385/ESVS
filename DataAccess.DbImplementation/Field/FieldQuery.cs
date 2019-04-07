using System;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using DB;
using Microsoft.EntityFrameworkCore;
using DataAccess.Field;
using ViewModel.Fields;

namespace DataAccess.DbImplementation.Field
{
    public class FieldQuery : IFieldQuery
    {
        private readonly AppDbContext _context;
        public FieldQuery(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<FieldResponse> RunAsync(Guid FieldId)
        {
            FieldResponse response = await _context.Fields
                .ProjectTo<FieldResponse>()
                .FirstOrDefaultAsync(p => p.Id == FieldId);
            return response;
        }
    }
}
