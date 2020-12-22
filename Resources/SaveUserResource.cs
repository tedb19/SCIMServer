using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCIMServer.Resources
{
    public class SaveUserResource
    {
        [Required]
        public int ExternalId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public NameResource Name { get; set; }
        public AddressResource Address { get; set; }
        [Required]
        public string Status { get; set; }
        public SaveGroupResource Group { get; set; }
        public SaveMetaResource Meta { get; set; }
        public IList<EmailResource> Emails { get; set; } = new List<EmailResource>();
    }
}
