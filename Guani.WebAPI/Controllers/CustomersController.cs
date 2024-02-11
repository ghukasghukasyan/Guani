using Guani.Application.Commands.V1_0.Customers;
using Guani.Application.Queries.Customers;
using Guani.DTO.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IReadOnlyList<CustomerDTO>>> Get([FromQuery] GetCustomersRequestDTO requestDTO)
        {
            var result = await _mediator.Send(new GetCustomersQuery(requestDTO));

            return Ok(result);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<CustomerDTO>> Create(CustomerDTO customer)
        {
            var result = await _mediator.Send(new CreateCustomerCommand(customer));

            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<CustomerDTO>> Update(CustomerDTO customer)
        {
            var result = await _mediator.Send(new UpdateCustomerCommand(customer));

            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteCustomerCommand(id));

            return Ok();
        }
    };

}