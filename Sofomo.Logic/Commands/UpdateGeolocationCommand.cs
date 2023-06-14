using Sofomo.Data;
using Sofomo.Logic.DTOs;

namespace Sofomo.Logic.Commands
{
    internal class UpdateGeolocationCommand : AbstractCommand
    {
        protected LocationDTO _location;
        public UpdateGeolocationCommand(AppDbContext dbContext, LocationDTO location) : base(dbContext)
        {
            _location = location;
        }

        override public void Execute()
        {
            var entity = _dbcontext.Locations.SingleOrDefault(x => x.Id == _location.Id);
            if (entity == null) {
                throw new ArgumentException($"The location entity with the id of {_location.Id} does not exist");
            }
            _dbcontext.Entry(entity).CurrentValues.SetValues(_location);

            _dbcontext.SaveChanges();
        }
    }
}