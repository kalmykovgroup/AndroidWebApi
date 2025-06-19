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

    [HttpPost("upload")]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded");

        var fileName = $"{Guid.NewGuid()}_{file.FileName}";
        var filePath = Path.Combine("wwwroot", "product", fileName);

        Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        // Возвращаем относительный путь
        return Ok(new { imageUrl = $"product/{fileName}" });
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var success = await _mediator.Send(new DeleteProductCommand(id));
      
       return Ok(success);
         
    }
}