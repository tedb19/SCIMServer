using System.Collections.Generic;

namespace SCIMServer.Domain.Models
{
    public class Group
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public IList<User> Users { get; set; } = new List<User>();
    }
}
