using System.ComponentModel.DataAnnotations;

namespace SCIMServer.Resources
{
    public class SaveUserResource
    {
        [Required]
        public int ExternalId { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Required]
        public NameResource Name { get; set; }
        public AddressResource Address { get; set; }
        [Required]
        public string Status { get; set; }
        public GroupResource Group { get; set; }
    }
}
