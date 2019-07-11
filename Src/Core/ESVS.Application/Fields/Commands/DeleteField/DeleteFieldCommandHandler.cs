using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ESVS.Application.Exceptions;
using ESVS.Application.Interfaces;
using ESVS.Domain.Entities;
using MediatR;

namespace ESVS.Application.Fields.Commands.DeleteField
{
    public class DeleteFieldCommandHandler:IRequestHandler<DeleteFieldCommand>
    {
         private readonly IESVSDbContext _context;

         public DeleteFieldCommandHandler(IESVSDbContext context) => 
             _context = context;

         public async Task<Unit> Handle(DeleteFieldCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Fields.FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Field), request.Id);

            entity.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
