using Guani.Domain.Core;
using Guani.Domain.Entities;
using Guani.Domain.Entities.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guani.Domain.Rules.GenericRules
{
    public class EntityExists<T> : BaseAsyncRule, IAsyncRule where T : EntityBase
    {
        private readonly Guid _id;
        private readonly IGuaniContext _guaniContext;

        public EntityExists(Guid id, IGuaniContext guaniContext, CancellationToken cancellationToken) :base(cancellationToken)
        {
            _id = id;
            _guaniContext = guaniContext;
        }
        public string Message => $"{typeof(T).Name} with the given id ({_id}) does not exist";


        public ErrorCode ErrorCode => ErrorCode.NotFound;

        public async Task<bool> IsBroken()    
        {
            return !await _guaniContext.Set<T>().AnyAsync(x => x.Id == _id, _cancellationToken);
        }
    }
}
