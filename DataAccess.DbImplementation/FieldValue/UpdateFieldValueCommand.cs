using System;
using System.Threading.Tasks;
using AutoMapper;
using DB;
using Microsoft.EntityFrameworkCore;

using DataAccess.FieldValue;
using ViewModel.FieldValues;

namespace DataAccess.DbImplementation.FieldValue
{
    public class UpdateFieldValueCommand : IUpdateFieldValuesCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateFieldValueCommand(AppDbContext dbContext, IMapper mappper)
        {
            _context = dbContext;
            _mapper = mappper;
        }
        public async Task<FieldValuesResponse> ExecuteAsync(Guid fieldValueId, UpdateFieldValuesRequest request)
        {
            Entities.FieldValue foundFieldValue = await _context.FieldValues.FirstOrDefaultAsync(t => t.Id == fieldValueId);
            if (foundFieldValue == null) return _mapper.Map<Entities.FieldValue, FieldValuesResponse>(null);
            Entities.FieldValue mappedFieldValue = _mapper.Map<UpdateFieldValuesRequest, Entities.FieldValue>(request);
            mappedFieldValue.Id = fieldValueId;
            _context.Entry(foundFieldValue).CurrentValues.SetValues(mappedFieldValue);
            await _context.SaveChangesAsync();
            return _mapper.Map<Entities.FieldValue, FieldValuesResponse>(foundFieldValue);
        }
    }
}
