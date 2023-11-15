using Guani.Domain.Core;
using Guani.Domain.Rules;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guani.Domain.Services
{
    public abstract class BaseDomainService
    {
        protected readonly IGuaniContext _guaniContext;
        protected readonly ILogger _logger;

        public BaseDomainService(IGuaniContext guaniContext, ILogger logger)
        {
            _guaniContext = guaniContext;
            _logger = logger;

        }

        protected static void CheckRule(IRule rule)
        {
            if (rule.IsBroken())
            {
                throw new Exception(rule.Message);

            }
        }


        protected static async Task CheckRule(IAsyncRule rule)
        {
            if (await rule.IsBroken())
            {
                throw new Exception(rule.Message);

            }
        }
    }
}
