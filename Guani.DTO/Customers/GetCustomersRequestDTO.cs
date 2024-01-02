using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guani.DTO.Customers
{
    public class GetCustomersRequestDTO
    {
        public string? Name { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
