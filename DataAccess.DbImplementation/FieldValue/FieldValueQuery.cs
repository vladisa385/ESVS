using System;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using DB;
using Microsoft.EntityFrameworkCore;
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

        public async Task<FieldValueResponse> RunAsync(Guid fieldValueId)
        {
            FieldValueResponse response = await _context.FieldValues
                .ProjectTo<FieldValueResponse>()
                .FirstOrDefaultAsync(p => p.Id == fieldValueId);
            return response;
        }
    }
}
