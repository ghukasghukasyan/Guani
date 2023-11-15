using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public decimal Price { get; private set; }
        public DateTime SubmitedDate { get; private set; }

        public Order()
        {
                
        }
    }
}
