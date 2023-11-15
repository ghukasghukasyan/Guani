using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guani.Domain.Rules
{
    public class BaseAsyncRule
    {
        protected readonly CancellationToken _cancellationToken;

        public BaseAsyncRule(CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;
        }
    }
}
