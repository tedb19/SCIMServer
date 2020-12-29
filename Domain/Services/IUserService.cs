using SCIMServer.Domain.Communication;
using SCIMServer.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCIMServer.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<UserResponse> SaveAsync(User user);
        Task<User> FindByIdAsync(string id);
        Task<UserResponse> UpdateAsync(string id, User user);
        Task<UserResponse> DeleteAsync(string id);
    }
}
