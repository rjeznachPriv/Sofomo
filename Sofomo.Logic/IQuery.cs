using System.Web.Http;

namespace Sofomo.Logic
{

    public interface IQuery
    {
        IEnumerable<DTOs.IDTO> Execute();
    }
}