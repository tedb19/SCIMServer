using System.ComponentModel.DataAnnotations;

namespace SCIMServer.Resources
{
    public class SaveGroupResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
