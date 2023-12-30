using Guani.Domain.Core;
using Guani.Domain.Rules;
using Microsoft.Extensions.Logging;

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

        protected static async Task CheckRuleAsync(IAsyncRule rule)
        {
            if (await rule.IsBroken())
            {
                throw new Exception(rule.Message);

            }
        }
    }
}
