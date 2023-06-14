using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofomo.Logic.Queries.Factories
{
    public interface IQueryFactory
    {
        IQuery GetGeolocationByIdQuery(Guid id);

        IQuery GetAllGeolocationsQuery();
    }
}
