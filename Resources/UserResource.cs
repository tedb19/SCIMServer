using Newtonsoft.Json;
using SCIMServer.Domain.Constants;
using SCIMServer.Domain.Models;
using System.Collections.Generic;

namespace SCIMServer.Resources
{
    public class UserResource
    {
        public IList<string> Schemas { get; set; } = new List<string> { SchemaUri.CorePrefix + Types.User, SchemaUri.CustomExtensionPrefix + Types.User, SchemaUri.EnterprisePrefix + Types.User };
        public string Id { get; set; }
        public string ExternalId { get; set; }
        public string UserName { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public bool? Active { get; set; }
        public MetaResource Meta { get; set; }
        public IList<EmailResource> Emails { get; set; } = new List<EmailResource>();
        [JsonProperty(SchemaUri.EnterprisePrefix + Types.User)]
        public EnterpriseUserExtension EnterpriseUserExtension { get; set; }
        [JsonProperty(SchemaUri.CustomExtensionPrefix + Types.User)]
        public CustomExtensions CustomExtensions { get; set; }
    }
}
