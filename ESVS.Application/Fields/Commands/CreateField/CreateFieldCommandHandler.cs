using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ESVS.Application.Catalogs.Commands.CreateCatalog;
using ESVS.Application.Exceptions;
using ESVS.Application.Interfaces;
using ESVS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Type = ESVS.Domain.Entities.Type;

namespace ESVS.Application.Fields.Commands.CreateField
{
    public class CreateFieldCommandHandler: IRequestHandler<CreateFieldCommand, Guid>
    {
        private readonly IESVSDbContext _context;
        private readonly IMapper _mapper;

        public CreateFieldCommandHandler(IESVSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateFieldCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CreateFieldCommand, Field>(request);

            if(await _context.Catalogs.AnyAsync(x => x.Id != entity.CatalogId, cancellationToken))
                throw  new NotFoundException(nameof(Catalog),entity.CatalogId);

            if (await _context.Types.AnyAsync(x => x.Id != entity.TypeId, cancellationToken))
                throw new NotFoundException(nameof(Type), entity.TypeId);

            await _context.Fields.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}