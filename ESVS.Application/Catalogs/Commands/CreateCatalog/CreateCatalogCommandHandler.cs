using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ESVS.Application.Interfaces;
using ESVS.Domain.Entities;
using MediatR;

namespace ESVS.Application.Catalogs.Commands.CreateCatalog
{
    public class CreateCatalogCommandHandler: IRequestHandler<CreateCatalogCommand, Guid>
    {
        private readonly IESVSDbContext _context;
        private readonly IMapper _mapper;

        public CreateCatalogCommandHandler(IESVSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateCatalogCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CreateCatalogCommand, Catalog>(request);
            await _context.Catalogs.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
