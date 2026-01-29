using LibraryOn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOn.Domain.Security.Tokens;
public interface IAccessTokenGenerator
{
    string Generate(Employee employee);
}
