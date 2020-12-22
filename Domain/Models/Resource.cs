using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCIMServer.Domain.Models
{
    public class Resource
    {
        public int ExternalId { get; set; }
        public int Id { get; set; }
        public Meta Meta { get; set; }
    }
}
