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
            var entity = _mapper.Map<UpdateFieldCommand, Field>(request);
            if (await _context.Fields.FindAsync(entity.Id) == null)
                throw new NotFoundException(nameof(Field), request.Id);

            if (await _context.Types.AnyAsync(x => x.Id != entity.TypeId, cancellationToken))
                throw new NotFoundException(nameof(Type), entity.TypeId);

            _context.Fields.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
