using System;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using DB;
using Microsoft.EntityFrameworkCore;
using DataAccess.FieldValue;
using ViewModel.FieldValues;

namespace DataAccess.DbImplementation.FieldValue
{
    public class FieldValueQuery : IFieldValuesQuery
    {
        private readonly AppDbContext _context;
        public FieldValueQuery(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<FieldValuesResponse> RunAsync(Guid fieldValueId)
        {
            FieldValuesResponse response = await _context.FieldValues
                .ProjectTo<FieldValuesResponse>()
                .FirstOrDefaultAsync(p => p.Id == fieldValueId);
            return response;
        }
    }
}
