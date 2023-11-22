using Guani.Application.Commands.V1_0.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DTO;

namespace OnlineShop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> Create(CustomerDTO customer)
        {
            var result = await _mediator.Send(new CreateCustomerCommand(customer));
            return Ok(result);
        }
    };

}