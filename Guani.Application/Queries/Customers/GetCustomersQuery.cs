using AutoMapper;
using Guani.Domain.Core;
using Guani.Domain.Entities.Customer;
using Guani.Domain.Interfaces.V1_0.Customers;
using Guani.DTO.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Guani.Application.Queries.Customers
{
    public class GetCustomersQuery : IQuery<IReadOnlyList<CustomerDTO>>
    {
        public GetCustomersRequestDTO Request { get; set; }
        public GetCustomersQuery(GetCustomersRequestDTO request)
        {
            Request = request;
        }
    }

    public class GetCustomersQueryHandler : BaseQueryHandler, IQueryHandler<GetCustomersQuery, IReadOnlyList<CustomerDTO>>
    {
        public ICustomerDomainService _customerDomainService;
        public GetCustomersQueryHandler(IGuaniContext guaniContext, IMapper mapper, ILogger<GetCustomersQueryHandler> logger, ICustomerDomainService customerDomainService) :
            base(guaniContext, mapper, logger)
        {
            _customerDomainService = customerDomainService;
        }
        public async Task<IReadOnlyList<CustomerDTO>> Handle(GetCustomersQuery customersQuery, CancellationToken cancellationToken)
        {
            var request = customersQuery.Request;

            IQueryable<Customer> query = _guaniContext.Customers.AsNoTracking();

            if (request.Name is not null)
            {
                query = query.Where(x => x.Name == request.Name);
            }

            if (request.Skip is not null)
            {
                query = query.Skip(request.Skip.Value);
            }

            if (request.Take is not null)
            {
                query = query.Take(request.Take.Value);
            }
            var customers = await query.ToListAsync(cancellationToken);

            return _mapper.Map<List<CustomerDTO>>(customers);
        }
    }
}
