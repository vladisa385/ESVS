using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ESVS.Application.Exceptions;
using ESVS.Application.Interfaces;
using ESVS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            var entity = _mapper.Map<UpdateCatalogCommand, Catalog>(request);
            if (await _context.Catalogs.FindAsync(entity.Id) == null)
                throw new NotFoundException(nameof(Catalog), request.Id);

            _context.Catalogs.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}