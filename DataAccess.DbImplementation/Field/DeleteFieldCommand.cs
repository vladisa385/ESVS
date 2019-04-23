using System;
using System.Threading.Tasks;
using DB;
using Microsoft.EntityFrameworkCore;
//
using DataAccess.Field;

namespace DataAccess.DbImplementation.Field
{
    public class DeleteFieldCommand : IDeleteFieldCommand
    {
        private readonly AppDbContext _context;

        public DeleteFieldCommand(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task ExecuteAsync(Guid fieldId)
        {
            Entities.Field fieldToDelete = await _context.Fields.FirstOrDefaultAsync(p => p.Id == fieldId);

            if (fieldToDelete != null)
            {
                _context.Fields.Remove(fieldToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
