using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ESVS.Application.Exceptions;
using ESVS.Application.Interfaces;
using ESVS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ESVS.Application.Catalogs.Queries.GetCatalog
{
    public class GetCatalogQueryHandler:IRequestHandler<GetCatalogQuery, CatalogViewModel>
    {
        private readonly IESVSDbContext _context;
        private readonly IMapper _mapper;

        public GetCatalogQueryHandler(IESVSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CatalogViewModel> Handle(GetCatalogQuery request, CancellationToken cancellationToken)
        {
            var catalog = await _context.Catalogs.
                   Include(u=>u.ChildCatalogs)
                  .ProjectTo<CatalogViewModel>(_mapper.ConfigurationProvider)
                  .SingleOrDefaultAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);
            if (catalog == null)
                throw new NotFoundException(nameof(Catalog), request.Id);
            return catalog;
        }
    }
}