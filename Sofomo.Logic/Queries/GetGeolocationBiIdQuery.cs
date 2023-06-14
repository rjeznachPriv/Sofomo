using Sofomo.Data;
using Sofomo.Domain.Exceptions;
using Sofomo.Logic.DTOs;
using System.Web.Http.Results;

namespace Sofomo.Logic.Queries
{
    public class GetGeolocationBiIdQuery : AbstractQuery
    {
        public Guid Id { get; private set; }

        public GetGeolocationBiIdQuery(AppDbContext dbContext, Guid id) : base(dbContext)
        {
            Id = id;
        }

        public override IEnumerable<IDTO> Execute()
        {
            var entity = _dbcontext.Locations.SingleOrDefault(x => x.Id == Id);
            if (entity == null) { throw new NotFoundException($"Location with id {Id} not found"); }
            return new List<LocationDTO>            
            {new LocationDTO            
                {
                    Id = entity.Id,
                    Latitude = entity.Latitude,
                    Longitude = entity.Longitude
                }
            };
        }
    }
}