using AutoMapper;
using Guani.Domain.Core;
using Guani.Domain.Interfaces.V1_0.Customers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guani.Application.Commands.V1_0.Customers
{
    public class DeleteCustomerCommand : ICommand
    {
        public Guid Id { get; set; }

        public DeleteCustomerCommand(Guid id)
        {
            Id = id;
        }
    }


    public class DeleteCustomerCommandHandler : BaseCommandHandler, ICommandHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerDomainService _customerDomainService;
        public DeleteCustomerCommandHandler(IGuaniContext guaniContext, IMapper mapper, ILogger<CreatCustomerCommandHandler> logger, ICustomerDomainService customerDomainService) : base(guaniContext, mapper, logger)
        {
            _customerDomainService = customerDomainService;
        }
        public Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
