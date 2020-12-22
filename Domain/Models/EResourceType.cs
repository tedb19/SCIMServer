using System.ComponentModel;

namespace SCIMServer.Domain.Models
{
    public enum EResourceType : byte
    {
        [Description("User")]
        User = 1,

        [Description("Group")]
        Group = 2,
    }
}