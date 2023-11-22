using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guani.Domain.Entities.Enum
{
    public enum ErrorCode
    {
        Unknown = 0,
        Validation = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        Conflict = 409,
        LargeRequest = 413,
        Internal = 500
    }

}
