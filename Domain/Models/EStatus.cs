using System.ComponentModel;

namespace SCIMServer.Domain.Models
{
    public enum EStatus: byte
    {
        [Description("active")]
        Active = 1,

        [Description("inactive")]
        Inactive = 2,
    }
}
