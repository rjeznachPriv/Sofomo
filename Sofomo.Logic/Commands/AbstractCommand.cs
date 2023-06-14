using Sofomo.Data;

namespace Sofomo.Logic.Commands
{
    public class AbstractCommand : ICommand
    {
        protected AppDbContext _dbcontext;

        public AbstractCommand(AppDbContext context)
        {
            _dbcontext = context;
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