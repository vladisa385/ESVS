using System.Threading.Tasks;
using AutoMapper;
using DB;
using DataAccess.FieldValue;
using ViewModel.FieldValues;

namespace DataAccess.DbImplementation.FieldValue
{
    public class CreateFieldValueCommand : ICreateFieldValuesCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateFieldValueCommand(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        public async Task<FieldValuesResponse> ExecuteAsync(CreateFieldValuesRequest request)
        {
            var fieldvalues = _mapper.Map<CreateFieldValuesRequest, Entities.FieldValue>(request);
            await _context.AddAsync(fieldvalues);
            await _context.SaveChangesAsync();
            return _mapper.Map<Entities.FieldValue, FieldValuesResponse>(fieldvalues);
        }
    }
}
