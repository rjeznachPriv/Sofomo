using AutoMapper;
using Sofomo.Data;

namespace Sofomo.Logic.Commands
{
    public class AbstractCommand : ICommand
    {
        protected AppDbContext _dbcontext;
        protected IMapper _mapper;

        public AbstractCommand(AppDbContext context, IMapper mapper)
        {
            _dbcontext = context;
            _mapper = mapper;
        }

        public virtual void Execute()
        {
            throw new NotImplementedException();
        }

        public virtual void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}