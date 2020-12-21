using System.Threading.Tasks;

namespace SCIMServer.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
