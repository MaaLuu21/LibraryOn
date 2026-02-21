using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOn.Communication.Requests.Loans
{
    public class RequestRegisterLoanJson
    {
        public long BookId { get; private set; }
        public long ReaderCpf { get; private set; }
        public DateTime LoanDate { get; private set; }
    }
}
