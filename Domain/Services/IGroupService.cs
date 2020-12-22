using SCIMServer.Domain.Communication;
using SCIMServer.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCIMServer.Domain.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> ListAsync();
        Task<GroupResponse> SaveAsync(Group Group);
        Task<Group> FindByIdAsync(int id);
        Task<GroupResponse> UpdateAsync(int id, Group Group);
        Task<GroupResponse> DeleteAsync(int id);
    }
}
