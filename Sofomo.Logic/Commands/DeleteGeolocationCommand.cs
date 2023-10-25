using AutoMapper;
using Sofomo.Data;

namespace Sofomo.Logic.Commands
{
    public class DeleteGeolocationCommand : AbstractCommand
    {
        private Guid _id;
        public DeleteGeolocationCommand(AppDbContext context, Guid id, IMapper mapper) : base(context, mapper)
        {
            _id = id;
        }

        override public void Execute()
        {
            var entity = _dbcontext.Locations.SingleOrDefault(x => x.Id == _id);
            if (entity == null) { return; } //Idempotent behaviour
            _dbcontext.Locations.Remove(entity);
            _dbcontext.SaveChanges();
        }
    }
}
