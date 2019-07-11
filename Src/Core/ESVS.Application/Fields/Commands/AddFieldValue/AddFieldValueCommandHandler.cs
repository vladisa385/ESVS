using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ESVS.Application.Exceptions;
using ESVS.Application.Fields.Commands.UpdateField;
using ESVS.Application.Interfaces;
using ESVS.Domain.Entities;
using MediatR;

namespace ESVS.Application.Fields.Commands.AddFieldValue
{
    public class AddFieldValueCommandHandler: IRequestHandler<AddFieldValueCommand, Guid>
    {
        private readonly IESVSDbContext _context;
        private readonly IMapper _mapper;

        public AddFieldValueCommandHandler(IESVSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AddFieldValueCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Fields.FindAsync(request.FieldId);
            if (entity == null)
                throw new NotFoundException(nameof(Field), request.FieldId);
            var mappedFieldValue = _mapper.Map<AddFieldValueCommand, FieldValue>(request);
            mappedFieldValue.Date = DateTime.Now;
            entity.FieldValues.Add(mappedFieldValue);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}