using Sofomo.Logic.DTOs;
using Sofomo.Data;

namespace Sofomo.Logic.Queries
{
    public class AbstractQuery : IQuery
    {
        protected AppDbContext _dbcontext;

        public AbstractQuery(AppDbContext context)
        {
            _dbcontext = context;
        }

        public virtual IEnumerable<IDTO> Execute()
        {
            throw new NotImplementedException();
        }
    }
}