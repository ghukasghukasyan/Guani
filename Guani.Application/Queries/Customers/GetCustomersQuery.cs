using AutoMapper;
using Chinchilla.Logging;
using Guani.Domain.Core;
using Guani.Domain.Entities.Customer;
using Guani.Domain.Interfaces.V1_0.Customers;
using Guani.DTO.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

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

            var customers = await query.ToListAsync(cancellationToken);

            return _mapper.Map<List<CustomerDTO>>(customers);
        }
    }
}
