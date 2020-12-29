using SCIMServer.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCIMServer.Resources
{
    public class SaveUserResource
    {
        [Required]
        public string ExternalId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public NameResource Name { get; set; }
        public AddressResource Address { get; set; }
        public bool Active { get; set; }
        public SaveGroupResource Group { get; set; }
        public SaveMetaResource Meta { get; set; }
        public IList<EmailResource> Emails { get; set; } = new List<EmailResource>();
        public EnterpriseUserExtension EnterpriseUserExtension { get; set; }
        public CustomExtensions CustomExtensions { get; set; }
    }
}
