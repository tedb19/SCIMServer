
using SCIMServer.Domain.Constants;
using System;
using System.Collections.Generic;

namespace SCIMServer.Resources
{
    public class GroupResource
    {
        public IList<string> Schemas { get; set; } = new List<string> { SchemaIdentifiers.TargettedSchemaPrefix + "Group" };
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
