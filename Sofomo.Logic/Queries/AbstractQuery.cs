using Sofomo.Logic.DTOs;
using Sofomo.Data;
using AutoMapper;

namespace Sofomo.Logic.Queries
{
    public class AbstractQuery : IQuery
    {
        protected AppDbContext _dbcontext;
        protected IMapper _mapper;

        public AbstractQuery(AppDbContext context, IMapper mapper)
        {
            _dbcontext = context;
            _mapper = mapper;
        }

        public virtual IEnumerable<IDTO> Execute()
        {
            throw new NotImplementedException();
        }
    }
}