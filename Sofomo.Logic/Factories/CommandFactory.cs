using Sofomo.Data;
using Sofomo.Domain.Entities;
using Sofomo.Logic.Commands;
using Sofomo.Logic.DTOs;

namespace Sofomo.Logic.Queries.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private AppDbContext _dbcontext;

        public CommandFactory(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public ICommand CreateGeolocationCommand(LocationDTO location)
        {
            return new CreateGeolocationCommand(_dbcontext, location);
        }

        public ICommand DeleteGeolocationCommand(Guid id)
        {
            return new DeleteGeolocationCommand(_dbcontext, id);
        }

        public ICommand UpdateGeolocationCommand(LocationDTO location)
        {
            return new UpdateGeolocationCommand(_dbcontext, location);
        }
    }
}
