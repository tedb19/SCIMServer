using System;

namespace SCIMServer.Domain.Models
{
    public class Meta
    {
        public EResourceType ResourceType { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
