using System;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Hosting;
using ViewModel;
using DB;
using Microsoft.EntityFrameworkCore;
//
using DataAccess.FieldValue;
using ViewModel.FieldValues;

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
            Entities.FieldValue FieldValueToDelete = await _context.FieldValue.FirstOrDefaultAsync(p => p.Id == FieldValueId);

            if (FieldValueToDelete != null)
            {
                _context.FieldValue.Remove(FieldValueToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
