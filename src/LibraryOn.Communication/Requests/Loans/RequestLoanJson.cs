using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOn.Communication.Requests.Loans
{
    public class RequestLoanJson
    {
        public long BookId { get; set; }
        public string Cpf { get; set; }
    }
}
