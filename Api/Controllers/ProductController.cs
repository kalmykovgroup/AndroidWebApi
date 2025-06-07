using Api.Contracts.Commands;
using Api.Contracts.Dtos;
using Api.Contracts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<ProductDto>>> Get()
    {
        var products = await _mediator.Send(new GetProductsQuery());
        return Ok(products);
    }

    [HttpPost("create")]
    public async Task<ActionResult<ProductDto>> Post([FromBody] AddProductCommand command)
    {
        var product = await _mediator.Send(command);
        return Ok(product);
    }

    [HttpPut("update")]
    public async Task<ActionResult<ProductDto>> Put([FromBody] UpdateProductCommand command)
    {
        var updated = await _mediator.Send(command);
        if (updated == null)
            return NotFound();

        return Ok(updated);
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var success = await _mediator.Send(new DeleteProductCommand(id));
      
       return Ok(success);
         
    }
}