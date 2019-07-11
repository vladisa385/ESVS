using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ESVS.Application.Catalogs.Queries;
using ESVS.Application.Exceptions;
using ESVS.Application.Interfaces;
using ESVS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ESVS.Application.Fields.Queries.GetField
{
    public class GetFieldQueryHandler:IRequestHandler<GetFieldQuery, FieldViewModel>
    {
        private readonly IESVSDbContext _context;
        private readonly IMapper _mapper;

        public GetFieldQueryHandler(IESVSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FieldViewModel> Handle(GetFieldQuery request, CancellationToken cancellationToken)
        {
            var field = await _context.Fields
                  .Include(u=>u.FieldValues)
                  .ProjectTo<FieldViewModel>(_mapper.ConfigurationProvider)
                  .SingleOrDefaultAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);
            if (field == null)
                throw new NotFoundException(nameof(Field), request.Id);
            return field;
        }
    }
}
