using AutoMapper;
using Sofomo.Data;
using Sofomo.Logic.DTOs;

namespace Sofomo.Logic.Queries
{
    [Serializable]
    internal class GetAllGeolocationsQuery : AbstractQuery
    {
        public GetAllGeolocationsQuery(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IEnumerable<IDTO> Execute()
        {
            var locations = _dbcontext.Locations.ToList();
            return locations.Select(x => _mapper.Map<LocationDTO>(x));
        }
    }
}