using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using DB;
using Microsoft.EntityFrameworkCore;

using DataAccess.Field;
using ViewModel.Fields;

namespace DataAccess.DbImplementation.Field
{


    public class UpdateFieldCommand : IUpdateFieldCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateFieldCommand(AppDbContext dbContext, IMapper mappper, IHostingEnvironment appEnvironment)
        {
            _context = dbContext;
            _mapper = mappper;
        }
        public async Task<FieldResponse> ExecuteAsync(Guid fieldId, UpdateFieldRequest request)
        {
            Entities.Field foundField = await _context.Fields.FirstOrDefaultAsync(t => t.Id == fieldId);
            if (foundField == null) return _mapper.Map<Entities.Field, FieldResponse>(null);
            Entities.Field mappedField = _mapper.Map<UpdateFieldRequest, Entities.Field>(request);
            mappedField.Id = fieldId;
            _context.Entry(foundField).CurrentValues.SetValues(mappedField);
            await _context.SaveChangesAsync();
            return _mapper.Map<Entities.Field, FieldResponse>(foundField);
        }
    }

}
