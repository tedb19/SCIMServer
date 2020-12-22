using SCIMServer.Domain.Constants;
using SCIMServer.Domain.Models;
using System.Collections.Generic;

namespace SCIMServer.Resources
{
    public class UserResource
    {
        public IList<string> Schemas { get; set; } = new List<string> { SchemaURI.CorePrefix + "User" };
        public int Id { get; set; }
        public int ExternalId { get; set; }
        public string UserName { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public string Status { get; set; }
        public MetaResource Meta { get; set; }
        public IList<EmailResource> Emails { get; set; } = new List<EmailResource>();
    }
}
