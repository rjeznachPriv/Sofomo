using AutoMapper;
using Sofomo.Data;
using Sofomo.Domain.Entities;
using Sofomo.Logic.Commands;
using Sofomo.Logic.DTOs;

namespace Sofomo.Logic.Queries.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private AppDbContext _dbcontext;
        private IMapper _mapper;

        public CommandFactory(AppDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public ICommand CreateGeolocationCommand(LocationDTO location)
        {
            return new CreateGeolocationCommand(_dbcontext, location, _mapper);
        }

        public ICommand DeleteGeolocationCommand(Guid id)
        {
            return new DeleteGeolocationCommand(_dbcontext, id, _mapper);
        }

        public ICommand UpdateGeolocationCommand(LocationDTO location)
        {
            return new UpdateGeolocationCommand(_dbcontext, location, _mapper);
        }
    }
}
