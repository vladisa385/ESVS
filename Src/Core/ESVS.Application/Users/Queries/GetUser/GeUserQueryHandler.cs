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

namespace ESVS.Application.Users.Queries.GetUser
{
    public class GeUserQueryHandler:IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly IESVSDbContext _context;
        private readonly IMapper _mapper;

        public GeUserQueryHandler(IESVSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                  .ProjectTo<UserViewModel>(_mapper.ConfigurationProvider)
                  .SingleOrDefaultAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);
            if (user == null)
                throw new NotFoundException(nameof(User), request.Id);
            return user;
        }
    }
}