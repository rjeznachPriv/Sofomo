using AutoMapper;
using Sofomo.Data;

namespace Sofomo.Logic.Queries.Factories
{
    public class QueryFactory : IQueryFactory
    {
        private AppDbContext _dbContext;
        private IMapper _mapper;

        public QueryFactory(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext= dbContext;
            _mapper= mapper;
        }

        public IQuery GetAllGeolocationsQuery()
        {
            return new GetAllGeolocationsQuery(_dbContext, _mapper);
        }

        public IQuery GetGeolocationByIdQuery(Guid id)
        {
            return new GetGeolocationBiIdQuery(_dbContext, id, _mapper);
        }
    }
}
