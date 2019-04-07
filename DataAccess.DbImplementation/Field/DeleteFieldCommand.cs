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
        public async Task ExecuteAsync(Guid FieldId)
        {
            Entities.Field FieldToDelete = await _context.Fields.FirstOrDefaultAsync(p => p.Id == FieldId);

            if (FieldToDelete != null)
            {
                _context.Fields.Remove(FieldToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
