using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ESVS.Application.Fields;
using ESVS.Application.Fields.Queries.GetListFields;
using ESVS.Application.Infrastructure.Query;
using ESVS.Application.Interfaces;

namespace ESVS.Application.Types.Queries.GetListTypes
{
    public class GetListTypesQueryHandler:BaseListQueryHandler<GetListTypesQuery,TypeViewModel>
    {
        private readonly IESVSDbContext _context;
        private readonly IMapper _mapper;

        public GetListTypesQueryHandler(IESVSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override IQueryable<TypeViewModel> ApplyFilter(IQueryable<TypeViewModel> query, GetListTypesQuery filter)
        {
            if (filter.Id != null)
                query = query.Where(p => p.Id == filter.Id);

            if (filter.Name != null)
                query = query.Where(p => p.Name.Contains(filter.Name));

            return query;
        }

        protected override IQueryable<TypeViewModel> GetQuery() => 
            _context.Types.ProjectTo<TypeViewModel>(_mapper.ConfigurationProvider);
    }
}