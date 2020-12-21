using SCIMServer.Domain.Constants;
using SCIMServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCIMServer.Resources
{
    public class UserResource
    {
        public IList<string> Schemas { get; set; } = new List<string> { SchemaIdentifiers.TargettedSchemaPrefix + "User" };
        public int Id { get; set; }
        public int ExternalId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public string Status { get; set; }
    }
}
