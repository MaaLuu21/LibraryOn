using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOn.Domain.Security.Cryptography;
public interface IPasswordEncripter
{
    string Encripty(string password);
    bool Verify(string password, string passworHash);
}
