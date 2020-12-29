using SCIMServer.Domain.Communication;
using SCIMServer.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCIMServer.Domain.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> ListAsync();
        Task<GroupResponse> SaveAsync(Group @group);
        Task<Group> FindByIdAsync(string id);
        Task<GroupResponse> UpdateAsync(string id, Group @group);
        Task<GroupResponse> DeleteAsync(string id);
    }
}
