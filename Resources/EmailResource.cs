using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCIMServer.Resources
{
    public class EmailResource
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public bool Primary { get; set; }
    }
}
