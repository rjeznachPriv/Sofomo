using AutoMapper;
using Sofomo.Data;
using Sofomo.Domain.Entities;
using Sofomo.Logic.DTOs;

namespace Sofomo.Logic.Queries
{
    public class GetAllGeolocationsQuery : AbstractQuery
    {
        public GetAllGeolocationsQuery(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IEnumerable<IDTO> Execute()
        {
            var locations = _dbcontext.Set<Location>().ToList();
            return locations.Select(x => _mapper.Map<LocationDTO>(x));
        }
    }
}