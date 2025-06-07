using Api.Contracts.Dtos;
using MediatR;

namespace Api.Contracts.Queries
{
    public record GetProductsQuery() : IRequest<ApiResponse<List<ProductDto>>>;
}
