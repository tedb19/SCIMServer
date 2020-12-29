using Microsoft.EntityFrameworkCore;
using SCIMServer.Domain.Models;
using SCIMServer.Domain.Repositories;
using SCIMServer.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCIMServer.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.Include(user => user.Emails).ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> FindByIdAsync(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }
    }
}
