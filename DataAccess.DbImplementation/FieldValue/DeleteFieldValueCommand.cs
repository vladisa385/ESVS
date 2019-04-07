using System;
using System.Threading.Tasks;
using DB;
using Microsoft.EntityFrameworkCore;
//
using DataAccess.FieldValue;

namespace DataAccess.DbImplementation.FieldValue
{
    public class DeleteFieldValueCommand : IDeleteFieldValuesCommand
    {
        private readonly AppDbContext _context;

        public DeleteFieldValueCommand(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task ExecuteAsync(Guid fieldValueId)
        {
            Entities.FieldValue fieldValueToDelete = await _context.FieldValues.FirstOrDefaultAsync(p => p.Id == fieldValueId);

            if (fieldValueToDelete != null)
            {
                _context.FieldValues.Remove(fieldValueToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
