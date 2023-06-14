using System.Web.Http;

namespace Sofomo.Logic
{

    public interface ICommand
    {
        void Execute();
        void Rollback();
    }
}