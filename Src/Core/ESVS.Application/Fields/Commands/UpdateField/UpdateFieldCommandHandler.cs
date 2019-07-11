using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ESVS.Application.Exceptions;
using ESVS.Application.Interfaces;
using ESVS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Type = ESVS.Domain.Entities.Type;

namespace ESVS.Application.Fields.Commands.UpdateField
{
    public class UpdateFieldCommandHandler: IRequestHandler<UpdateFieldCommand, Guid>
    {
        private readonly IESVSDbContext _context;
        private readonly IMapper _mapper;

        public UpdateFieldCommandHandler(IESVSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(UpdateFieldCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Fields.FindAsync(request.Id);
            if (entity == null)
                throw new NotFoundException(nameof(Field), request.Id);
            var mappedEntity = _mapper.Map<UpdateFieldCommand, Field>(request);
            mappedEntity.CatalogId = entity.CatalogId;
            _context.UpdateEntity(entity, mappedEntity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
