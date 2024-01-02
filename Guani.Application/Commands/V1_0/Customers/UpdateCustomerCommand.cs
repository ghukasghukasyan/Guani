using AutoMapper;
using Guani.Domain.Core;
using Guani.Domain.Interfaces.V1_0.Customers;
using Guani.DTO.Customers;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Guani.Application.Commands.V1_0.Customers
{
    public class UpdateCustomerCommand : ICommand<CustomerDTO>
    {
        public CustomerDTO Customer { get; set; }
        public UpdateCustomerCommand(CustomerDTO customer)
        {
            Customer = customer;
        }
    }

    public class UpdateCustomerCommandHandler : BaseCommandHandler, ICommandHandler<UpdateCustomerCommand, CustomerDTO>
    {
        private readonly ICustomerDomainService _customerDomainSerice;

        public UpdateCustomerCommandHandler(IGuaniContext guaniContext, IMapper mapper, ILogger<UpdateCustomerCommand> logger, ICustomerDomainService customerDomainService) : base(guaniContext, mapper, logger)
        {
            _customerDomainSerice = customerDomainService;
        }
        public Task<CustomerDTO> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
