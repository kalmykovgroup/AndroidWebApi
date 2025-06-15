using Api.Models;
using MediatR;

namespace Api.Contracts.Commands.Orders
{
    public record UpdateOrderStatusCommand(Guid OrderId, string Status) : IRequest<ApiResponse<bool>>;

}
