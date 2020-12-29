using System.ComponentModel;

namespace SCIMServer.Domain.Models
{
    public enum EType : byte
    {
        [Description("Work")]
        Work = 1,

        [Description("Home")]
        Home = 2,
    }
}
