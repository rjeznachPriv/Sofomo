using Sofomo.Data;
using Sofomo.Logic.DTOs;

namespace Sofomo.Logic.Commands
{
    internal class CreateGeolocationCommand : AbstractCommand
    {
        protected LocationDTO _location;
        public CreateGeolocationCommand(AppDbContext dbContext, LocationDTO location) : base(dbContext)
        {
            _location = location;
        }

        override public void Execute()
        {
            if (_dbcontext.Locations.SingleOrDefault(x => x.Id == _location.Id) != null) {
                throw new ArgumentException($"The location with id of {_location.Id} already exists");
            }

            var entity = new Domain.Entities.Location
            {
                Id = _location.Id, 
                Latitude = _location.Latitude,
                Longitude = _location.Longitude
            };

            _dbcontext.Locations.Add(entity);
            _dbcontext.SaveChanges();
        }
    }
}