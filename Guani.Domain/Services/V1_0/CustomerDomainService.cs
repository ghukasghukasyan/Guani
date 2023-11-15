using Guani.Domain.Core;
using Guani.Domain.Interfaces.V1_0.Customers;
using Microsoft.Extensions.Logging;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guani.Domain.Services.V1_0
{
    public class CustomerDomainService : BaseDomainService, ICustomerDomainService
    {
        public CustomerDomainService(IGuaniContext guaniContext, ILogger<CustomerDomainService> logger) : base(guaniContext, logger)
        {
                
        }
        public async Task<Customer> CreateAsync(Customer customer, CancellationToken cancellationToken)
        {
            var newCustomer = new Customer(new Guid(), customer.Name, customer.Surname, customer.PhoneNumber);

            var result = await _guaniContext.Customers.AddAsync(newCustomer, cancellationToken);

            return result.Entity;
        }

        public Task DeleteAsync(Customer entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateAsync(Customer entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
