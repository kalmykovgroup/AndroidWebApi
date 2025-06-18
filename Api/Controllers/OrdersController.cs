using Api.Contracts.Commands;
using Api.Contracts.Commands.Orders;
using Api.Contracts.Dtos;
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

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllOrdersQuery());
            return result.Success ? Ok(result) : StatusCode(500, result);
        }

        [HttpPut("{id:guid}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateOrderStatusRequest request)
        {
            var result = await _mediator.Send(new UpdateOrderStatusCommand(id, request.Status));
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
