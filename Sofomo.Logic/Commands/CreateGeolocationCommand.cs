using AutoMapper;
using Sofomo.Data;
using Sofomo.Domain.Entities;
using Sofomo.Logic.DTOs;

namespace Sofomo.Logic.Commands
{
    internal class CreateGeolocationCommand : AbstractCommand
    {
        protected LocationDTO _location;
        public CreateGeolocationCommand(AppDbContext dbContext, LocationDTO location, IMapper mapper) : base(dbContext, mapper)
        {
            _location = location;
        }

        override public void Execute()
        {
            if (_dbcontext.Locations.SingleOrDefault(x => x.Id == _location.Id) != null) {
                throw new ArgumentException($"The location with id of {_location.Id} already exists");
            }

            _dbcontext.Locations.Add(_mapper.Map<Location>(_location));
            _dbcontext.SaveChanges();
        }
    }
}