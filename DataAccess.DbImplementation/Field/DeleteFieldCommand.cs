using System;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Hosting;
using ViewModel;
using DB;
using Microsoft.EntityFrameworkCore;
//
using DataAccess.Field;
using ViewModel.Fields;

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
            Field FieldToDelete = await _context.Field.FirstOrDefaultAsync(p => p.Id == FieldId);

            if (FieldToDelete != null)
            {
                _context.Field.Remove(FieldToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
