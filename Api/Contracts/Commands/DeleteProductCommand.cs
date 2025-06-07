using MediatR;

namespace Api.Contracts.Commands
{
    public record DeleteProductCommand(Guid ProductId) : IRequest<ApiResponse<bool>>;
}
