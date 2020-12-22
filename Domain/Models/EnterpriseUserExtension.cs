using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCIMServer.Domain.Models
{
    public class EnterpriseUserExtension
    {
        string EmployeeNumber { get; set; }
        string Organization { get; set; }
        string Department { get; set; }
    }
}
