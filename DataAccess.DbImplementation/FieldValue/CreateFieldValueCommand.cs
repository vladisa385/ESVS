using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DB;
using DataAccess.FieldValue;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ViewModel.FieldValues;

namespace DataAccess.DbImplementation.FieldValue
{
    public class CreateFieldValueCommand : ICreateFieldValuesCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateFieldValueCommand(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        public async Task<FieldValuesResponse> ExecuteAsync(CreateFieldValuesRequest request)
        {
            if (!await _context.Fields.AnyAsync(u => u.Id == request.FieldId))
                throw new CannotCreateFieldValuesException(
                    new List<IdentityError>()
                    {
                        new IdentityError()
                        {
                            Description = "Field with with Id doesnt exist"
                        }
                    }
                    );
            var fieldvalues = _mapper.Map<CreateFieldValuesRequest, Entities.FieldValue>(request);
            await _context.AddAsync(fieldvalues);
            await _context.SaveChangesAsync();
            return _mapper.Map<Entities.FieldValue, FieldValuesResponse>(fieldvalues);
        }
    }
}
