using System;

namespace SCIMServer.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public int ExternalId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public EStatus Status { get; set; }
        public Group Group { get; set; }
        public int? GroupId { get; set; }
    }
}
