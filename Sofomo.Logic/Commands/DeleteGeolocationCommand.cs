using Sofomo.Data;

namespace Sofomo.Logic.Commands
{
    internal class DeleteGeolocationCommand : AbstractCommand
    {
        private Guid _id;
        public DeleteGeolocationCommand(AppDbContext context, Guid id) : base(context)
        {
            _id = id;
        }

        override public void Execute()
        {
            var entity = _dbcontext.Locations.SingleOrDefault(x => x.Id == _id);
            if (entity == null) { return; } //Idempotence behaviour
            _dbcontext.Locations.Remove(entity);
            _dbcontext.SaveChanges();
        }
    }
}
