using SCIMServer.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCIMServer.Domain.Repositories
{
    interface IGroupRepository
    {
        Task<IEnumerable<Group>> ListAsync();
        Task AddAsync(Group Group);
        Task<Group> findByIdAsync(int id);
        void Update(Group Group);
        void Remove(Group Group);
    }
}
