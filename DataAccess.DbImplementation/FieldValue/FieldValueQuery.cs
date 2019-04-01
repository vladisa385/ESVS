using System;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using DB;
using Microsoft.EntityFrameworkCore;
using ViewModel;

using DataAccess.FieldValue;
using ViewModel.FieldValues;

namespace DataAccess.DbImplementation.FieldValue
{
    public class FieldValueQuery : IFieldValueQuery
    {
        private readonly AppDbContext _context;
        public FieldValueQuery(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<FieldValueResponse> RunAsync(Guid FieldValueId)
        {
            FieldValueResponse response = await _context.FieldValue
                .ProjectTo<FieldValueResponse>()
                .FirstOrDefaultAsync(p => p.Id == FieldValueId);
            return response;
        }
    }
}
