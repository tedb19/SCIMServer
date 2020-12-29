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

        public async Task AddAsync(Group @group)
        {
            await _context.Groups.AddAsync(@group);
        }

        public async Task<Group> FindByIdAsync(string id)
        {
            return await _context.Groups.FindAsync(id);
        }

        public void Update(Group @group)
        {
            _context.Groups.Update(@group);
        }

        public void Remove(Group @group)
        {
            _context.Groups.Remove(@group);
        }
    }
}
