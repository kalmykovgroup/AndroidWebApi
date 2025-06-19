using Api.Contracts;
using Api.Contracts.Commands;
using Api.Contracts.Dtos;
using Api.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, ApiResponse<ProductDto>>
    {
        private readonly IProductRepository _repository;

        public AddProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<ProductDto>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new ProductDto
            {
                Name = request.ProductDto.Name,
                Price = request.ProductDto.Price,
                Description = request.ProductDto.Description,
                ImageUrl = request.ProductDto.ImageUrl
            };
            var result = await _repository.AddAsync(product);

            return ApiResponse<ProductDto>.Ok(result);
        }
    }
}
