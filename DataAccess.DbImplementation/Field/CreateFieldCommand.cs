using System.Threading.Tasks;
using AutoMapper;
using DB;
using Entities;
using ViewModel;

using DataAccess.Field;
using ViewModel.Fields;

namespace DataAccess.DbImplementation.Field
{
    public class CreateFieldCommand : ICreateFieldCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateFieldCommand(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        public async Task<FieldResponse> ExecuteAsync(CreateFieldRequest request)
        {
            var field = _mapper.Map<CreateFieldRequest, Entities.Field>(request);
            await _context.AddAsync(field);
            await _context.SaveChangesAsync();
            return _mapper.Map<Entities.Field, FieldResponse>(field);
        }
    }
}
