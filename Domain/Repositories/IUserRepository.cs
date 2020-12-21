using SCIMServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCIMServer.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task AddAsync(User User);
        Task<User> findByIdAsync(int id);
        void Update(User User);
        void Remove(User User);
    }
}
