using SCIMServer.Domain.Communication;
using SCIMServer.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCIMServer.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<UserResponse> SaveAsync(User User);
        Task<UserResponse> UpdateAsync(int id, User User);
        Task<UserResponse> DeleteAsync(int id);
    }
}
