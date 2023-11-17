using AutoMapper;
using Guani.Domain.Core;
using Guani.Domain.Interfaces.V1_0.Customers;
using Microsoft.Extensions.Logging;
using OnlineShop.Domain.Entities;
using OnlineShop.DTO;

namespace Guani.Application.Commands.V1_0.Customers
{
    public class CreateCustomerCommand : ICommand<CustomerDTO>
    {
        public CustomerDTO Customer { get; set; }

        public CreateCustomerCommand(CustomerDTO customer)
        {
            Customer = customer;
        }
    }


    public class CreatCustomerCommandHandler : BaseCommandHandler, ICommandHandler<CreateCustomerCommand, CustomerDTO>
    {
        private readonly ICustomerDomainService _customerDomainService;
        public CreatCustomerCommandHandler(IGuaniContext guaniContext, IMapper mapper, ILogger<CreatCustomerCommandHandler> logger, ICustomerDomainService customerDomainService) : base(guaniContext, mapper, logger)
        {
            _customerDomainService = customerDomainService;
        }
        public async Task<CustomerDTO> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request.Customer);

            var createdCustomer = await _customerDomainService.CreateAsync(customer, cancellationToken);

            return new CustomerDTO { };
        }
    }
}
