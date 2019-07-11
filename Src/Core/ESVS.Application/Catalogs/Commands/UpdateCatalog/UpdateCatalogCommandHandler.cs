using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ESVS.Application.Exceptions;
using ESVS.Application.Interfaces;
using ESVS.Domain.Entities;
using MediatR;

namespace ESVS.Application.Catalogs.Commands.UpdateCatalog
{
    public class UpdateCatalogCommandHandler:IRequestHandler<UpdateCatalogCommand, Guid>
    {
        private readonly IESVSDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCatalogCommandHandler(IESVSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(UpdateCatalogCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Catalogs.FindAsync(request.Id);
            if (entity == null)
                throw new NotFoundException(nameof(Catalog), request.Id);
            var mappedEntity = _mapper.Map<UpdateCatalogCommand, Catalog>(request);
            _context.UpdateEntity(entity,mappedEntity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}