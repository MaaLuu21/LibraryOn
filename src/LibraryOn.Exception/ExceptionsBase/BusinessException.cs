using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOn.Exception.ExceptionsBase;
public class BusinessException : LibraryOnException
{
    public BusinessException() : base(ResourceErrorMessages.ADMIN_CAN_NOT_BE_DEMOTED)
    {
    }

    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}
