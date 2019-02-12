using System;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Hosting;
using ViewModel;
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
            private readonly IHostingEnvironment _appEnvironment;

            public UpdateFieldCommand(AppDbContext dbContext, IMapper mappper, IHostingEnvironment appEnvironment)
            {
                _context = dbContext;
                _mapper = mappper;
                _appEnvironment = appEnvironment;
            }
            public async Task<FieldResponse> ExecuteAsync(Guid typefoodId, UpdateFieldRequest request)
            {
                Entities.Field foundField = await _context.Field.FirstOrDefaultAsync(t => t.Id == typefoodId);
                if (foundField == null) return _mapper.Map<Entities.Field, FieldResponse>(foundField);
                Entities.Field mappedField = _mapper.Map<UpdateFieldRequest, Entities.Field>(request);
                mappedField.Id = typefoodId;
                _context.Entry(foundField).CurrentValues.SetValues(mappedField);
                await _context.SaveChangesAsync();
                return _mapper.Map<Entities.Field, FieldResponse>(foundField);
            }
        }
    
}
