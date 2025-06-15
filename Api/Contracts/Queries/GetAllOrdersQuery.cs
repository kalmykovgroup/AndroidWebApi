using Api.Contracts.Dtos;
using MediatR;

namespace Api.Contracts.Queries
{
    public record GetAllOrdersQuery : IRequest<ApiResponse<List<OrderDto>>>;
}
