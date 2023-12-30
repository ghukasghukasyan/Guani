using AutoMapper;
using Guani.Domain.Core;
using Guani.Domain.Interfaces.V1_0.Customers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
        public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var existing = await _guaniContext.Customers.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (existing == null)
            {
                throw new Exception($"Customer with the given id {request.Id} does not exist");
            }

            await _customerDomainService.DeleteAsync(existing, cancellationToken);

            return;
        }

    }
}
