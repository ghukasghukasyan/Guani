using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guani.DTO
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public DateTime SubmitedDate { get; set; }
    }
}
