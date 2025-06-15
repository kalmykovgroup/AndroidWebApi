using Api.Contracts.Commands;
using Api.Contracts.Commands.Orders;
using Api.Contracts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllOrdersQuery());
            return result.Success ? Ok(result) : StatusCode(500, result);
        }

        [HttpPut("{id:guid}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] string status)
        {
            var result = await _mediator.Send(new UpdateOrderStatusCommand(id, status));
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
