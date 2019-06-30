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
    public class UpdateCatalogCommandHandler:IRequestHandler<UpdateCatalogCommand, Unit>
    {
        private readonly IESVSDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCatalogCommandHandler(IESVSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCatalogCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UpdateCatalogCommand, Catalog>(request);
            if (await _context.Catalogs.Get(entity.Id) == null)
                throw new NotFoundException(nameof(Catalog), request.Id);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}