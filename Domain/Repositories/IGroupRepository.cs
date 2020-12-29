using SCIMServer.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCIMServer.Domain.Repositories
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> ListAsync();
        Task AddAsync(Group @group);
        Task<Group> FindByIdAsync(string id);
        void Update(Group @group);
        void Remove(Group @group);
    }
}
