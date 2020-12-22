using SCIMServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCIMServer.Resources
{
    public class MetaResource
    {
        public string ResourceType { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
