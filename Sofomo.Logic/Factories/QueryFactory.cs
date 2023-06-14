using Sofomo.Data;
using Sofomo.Domain;
using Sofomo.Domain.Entities;

namespace Sofomo.Logic.Queries.Factories
{
    public class QueryFactory : IQueryFactory
    {
        private AppDbContext _dbContext;

        public QueryFactory(AppDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public IQuery GetAllGeolocationsQuery()
        {
            return new GetAllGeolocationsQuery(_dbContext);
        }

        public IQuery GetGeolocationByIdQuery(Guid id)
        {
            return new GetGeolocationBiIdQuery(_dbContext, id);
        }
    }
}
