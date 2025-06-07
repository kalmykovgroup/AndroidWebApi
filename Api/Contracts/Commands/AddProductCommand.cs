using Api.Contracts.Dtos;
using MediatR;

namespace Api.Contracts.Commands
{
    public record AddProductCommand(ProductDto ProductDto) : IRequest<ApiResponse<ProductDto>>;


}
