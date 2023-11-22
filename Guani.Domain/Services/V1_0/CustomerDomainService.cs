using Guani.Domain.Core;
using Guani.Domain.Entities.Customer;
using Guani.Domain.Interfaces.V1_0.Customers;
using Microsoft.Extensions.Logging;
using OnlineShop.Domain.Entities;

namespace Guani.Domain.Services.V1_0
{
    public class CustomerDomainService : BaseDomainService, ICustomerDomainService
    {
        public CustomerDomainService(IGuaniContext guaniContext, ILogger<CustomerDomainService> logger) : base(guaniContext, logger)
        {

        }
        public async Task<Customer> CreateAsync(Customer customer, CancellationToken cancellationToken)
        {
            customer.InitializeId();

            var newCustomer = new Customer(customer.Id, customer.Name, customer.Surname, customer.PhoneNumber);

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
