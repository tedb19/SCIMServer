using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCIMServer.Domain.Models
{
    public class Meta
    {
        public EResourceType ResourceType { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
