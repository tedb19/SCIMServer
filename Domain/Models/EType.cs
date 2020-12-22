using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

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
