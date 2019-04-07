using System.Threading.Tasks;
using AutoMapper;
using DB;
using DataAccess.FieldValue;
using ViewModel.FieldValues;

namespace DataAccess.DbImplementation.FieldValue
{
    public class CreateFieldValueCommand : ICreateFieldValueCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateFieldValueCommand(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        public async Task<FieldValueResponse> ExecuteAsync(CreateFieldValueRequest request)
        {
            var fieldvalue = _mapper.Map<CreateFieldValueRequest, Entities.FieldValue>(request);
            await _context.AddAsync(fieldvalue);
            await _context.SaveChangesAsync();
            return _mapper.Map<Entities.FieldValue, FieldValueResponse>(fieldvalue);
        }
    }
}
