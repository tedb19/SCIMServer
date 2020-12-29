using System;

namespace SCIMServer.Resources
{
    public class MetaResource
    {
        public string ResourceType { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
