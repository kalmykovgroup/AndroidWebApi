using Api.Contracts;
using Api.Contracts.Commands;
using Api.Contracts.Dtos;
using Api.Interfaces;
using MediatR;

namespace Api.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ApiResponse<bool>>
    {
        private readonly IProductRepository _repository;

        public DeleteProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.ProductId);

            return ApiResponse<bool>.Ok(true);
        }
    }
}
