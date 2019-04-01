using System;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Hosting;
using ViewModel;
using DB;
using Microsoft.EntityFrameworkCore;

using DataAccess.FieldValue;
using ViewModel.FieldValues;

namespace DataAccess.DbImplementation.FieldValue
{
    public class UpdateFieldValueCommand : IUpdateFieldValueCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;

        public UpdateFieldValueCommand(AppDbContext dbContext, IMapper mappper, IHostingEnvironment appEnvironment)
        {
            _context = dbContext;
            _mapper = mappper;
            _appEnvironment = appEnvironment;
        }
        public async Task<FieldValueResponse> ExecuteAsync(Guid typefoodId, UpdateFieldValueRequest request)
        {
            Entities.FieldValue foundFieldValue = await _context.FieldValue.FirstOrDefaultAsync(t => t.Id == typefoodId);
            if (foundFieldValue == null) return _mapper.Map<Entities.FieldValue, FieldValueResponse>(foundFieldValue);
            Entities.FieldValue mappedFieldValue = _mapper.Map<UpdateFieldValueRequest, Entities.FieldValue>(request);
            mappedFieldValue.Id = typefoodId;
            _context.Entry(foundFieldValue).CurrentValues.SetValues(mappedFieldValue);
            await _context.SaveChangesAsync();
            return _mapper.Map<Entities.FieldValue, FieldValueResponse>(foundFieldValue);
        }
    }
}
