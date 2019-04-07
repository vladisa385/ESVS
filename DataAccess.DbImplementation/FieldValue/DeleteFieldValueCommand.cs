using System;
using System.Threading.Tasks;
using DB;
using Microsoft.EntityFrameworkCore;
//
using DataAccess.FieldValue;

namespace DataAccess.DbImplementation.FieldValue
{
    public class DeleteFieldValueCommand : IDeleteFieldValueCommand
    {
        private readonly AppDbContext _context;

        public DeleteFieldValueCommand(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task ExecuteAsync(Guid FieldValueId)
        {
            Entities.FieldValue FieldValueToDelete = await _context.FieldValues.FirstOrDefaultAsync(p => p.Id == FieldValueId);

            if (FieldValueToDelete != null)
            {
                _context.FieldValues.Remove(FieldValueToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
