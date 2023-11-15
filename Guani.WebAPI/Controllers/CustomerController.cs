using Guani.Application.Commands.V1_0.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DTO;

namespace OnlineShop.Controllers
{
    [ApiController]
    [Route("[Customer]")]
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult<CustomerDTO>> Create(CustomerDTO customerDTO)
        {
            var result = await _mediator.Send(new CreateCustomerCommand(customerDTO));
            return Ok(result);
        }
    };

}