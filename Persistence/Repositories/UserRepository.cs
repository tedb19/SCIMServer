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

        public async Task AddAsync(User User)
        {
            await _context.Users.AddAsync(User);
        }

        public async Task<User> findByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void Update(User User)
        {
            _context.Users.Update(User);
        }

        public void Remove(User User)
        {
            _context.Users.Remove(User);
        }
    }
}
