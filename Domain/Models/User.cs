using System.Collections.Generic;

namespace SCIMServer.Domain.Models
{
    public class User : Resource
    {
        public string UserName { get; set; }
        public IList<Email> Emails { get; set; } = new List<Email>();
        public Name Name { get; set; }
        public Address Address { get; set; }
        public bool? Active { get; set; }
        public Group Group { get; set; }
        public string GroupId { get; set; }
        public EnterpriseUserExtension EnterpriseUserExtension { get; set; }
        public CustomExtensions CustomExtensions { get; set; }

    }
}
