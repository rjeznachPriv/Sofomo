using AutoMapper;
using Sofomo.Data;
using Sofomo.Domain.Exceptions;
using Sofomo.Logic.DTOs;

namespace Sofomo.Logic.Queries
{
    public class GetGeolocationBiIdQuery : AbstractQuery
    {
        public Guid Id { get; private set; }

        public GetGeolocationBiIdQuery(AppDbContext dbContext, Guid id, IMapper mapper) : base(dbContext, mapper)
        {
            Id = id;
        }

        public override IEnumerable<IDTO> Execute()
        {
            var entity = _dbcontext.Locations.SingleOrDefault(x => x.Id == Id);
            if (entity == null) { throw new NotFoundException($"Location with id {Id} not found"); }
            return new List<LocationDTO> { _mapper.Map<LocationDTO>(entity) };
        }
    }
}