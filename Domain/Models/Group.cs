using System.Collections.Generic;

namespace SCIMServer.Domain.Models
{
    public class Group : Resource
    {
        public string Name { get; set; }
        public IList<User> Users { get; set; } = new List<User>();
    }
}
