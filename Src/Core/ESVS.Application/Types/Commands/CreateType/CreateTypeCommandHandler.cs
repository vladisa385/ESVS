using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ESVS.Application.Interfaces;
using MediatR;
using Type = ESVS.Domain.Entities.Type ;
namespace ESVS.Application.Types.Commands.CreateType
{
    public class CreateTypeCommandHandler: IRequestHandler<CreateTypeCommand, Guid>
    {
        private readonly IESVSDbContext _context;
        private readonly IMapper _mapper;

        public CreateTypeCommandHandler(IMapper mapper, IESVSDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Guid> Handle(CreateTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CreateTypeCommand, Type>(request);
            await _context.Types.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}