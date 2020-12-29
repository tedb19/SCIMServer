using SCIMServer.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCIMServer.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task AddAsync(User user);
        Task<User> FindByIdAsync(string id);
        void Update(User user);
        void Remove(User user);
    }
}
