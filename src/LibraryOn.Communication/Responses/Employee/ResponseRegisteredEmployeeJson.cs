using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOn.Communication.Responses.Employee;
public class ResponseRegisteredEmployeeJson
{
    public string Name { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public bool MustChangePassword { get; set; }
}
