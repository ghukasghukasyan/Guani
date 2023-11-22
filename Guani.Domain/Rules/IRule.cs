using Guani.Domain.Entities;
using Guani.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guani.Domain.Rules
{
    public interface IRule
    {
        bool IsBroken();
        string Message { get; }
        ErrorCode ErrorCode { get; }
    }
}
