using Microsoft.EntityFrameworkCore;
using SCIMServer.Domain.Models;
using SCIMServer.Domain.Repositories;
using SCIMServer.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCIMServer.Persistence.Repositories
{
    public class GroupRepository : BaseRepository, IGroupRepository
    {
        public GroupRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Group>> ListAsync()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task AddAsync(Group Group)
        {
            await _context.Groups.AddAsync(Group);
        }

        public async Task<Group> findByIdAsync(int id)
        {
            return await _context.Groups.FindAsync(id);
        }

        public void Update(Group Group)
        {
            _context.Groups.Update(Group);
        }

        public void Remove(Group Group)
        {
            _context.Groups.Remove(Group);
        }
    }
}
