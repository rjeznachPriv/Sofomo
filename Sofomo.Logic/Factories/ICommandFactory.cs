using Sofomo.Logic.DTOs;

namespace Sofomo.Logic.Queries.Factories
{
    public interface ICommandFactory
    {
        ICommand DeleteGeolocationCommand(Guid guid);
        ICommand CreateGeolocationCommand(LocationDTO location);
        ICommand UpdateGeolocationCommand(LocationDTO location);
    }
}
