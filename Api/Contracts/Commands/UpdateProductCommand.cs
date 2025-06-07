using Api.Contracts.Dtos;
using MediatR;

namespace Api.Contracts.Commands
{ 
    public record UpdateProductCommand(ProductDto ProductDto) : IRequest<ApiResponse<ProductDto>>;
}
