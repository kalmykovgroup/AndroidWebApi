using Api.Contracts;
using Api.Contracts.Commands;
using Api.Contracts.Dtos;
using Api.Interfaces;
using MediatR;

namespace Api.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ApiResponse<ProductDto>>
    {
        private readonly IProductRepository _repository;

        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<ProductDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var updated = await _repository.UpdateAsync(request.ProductDto);
            return ApiResponse<ProductDto>.Ok(updated);
        }
    }
}
