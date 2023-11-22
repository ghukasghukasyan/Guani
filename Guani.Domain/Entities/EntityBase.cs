using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guani.Domain.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public void InitializeId()
        {
            Id = Guid.NewGuid();
        }
    }
}
