using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ESVS.Application.Exceptions;
using ESVS.Application.Interfaces;
using ESVS.Domain.Entities;
using MediatR;

namespace ESVS.Application.Catalogs.Commands.DeleteCatalog
{
    public class DeleteCatalogCommandHandler: IRequestHandler<DeleteCatalogCommand>
    {
        private readonly IESVSDbContext _context;
        public async Task<Unit> Handle(DeleteCatalogCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Catalogs.Get(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Catalog), request.Id);

            entity.IsDeleted = true;
            await _context.Catalogs.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
