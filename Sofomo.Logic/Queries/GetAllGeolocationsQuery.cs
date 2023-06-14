using Sofomo.Data;
using Sofomo.Logic.DTOs;

namespace Sofomo.Logic.Queries
{
    [Serializable]
    internal class GetAllGeolocationsQuery : AbstractQuery
    {
        public GetAllGeolocationsQuery(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<IDTO> Execute()
        {
            return _dbcontext.Locations.Select(x => new LocationDTO
            {
                Id = x.Id,
                Latitude = x.Latitude,
                Longitude = x.Longitude
            });
        }
    }
}