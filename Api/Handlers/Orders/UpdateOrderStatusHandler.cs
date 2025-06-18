using Api.Contracts;
using Api.Contracts.Commands;
using Api.Contracts.Commands.Orders;
using Api.Contracts.Dtos;
using Api.Contracts.Queries;
using Api.Interfaces;
using Api.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Handlers.Orders
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
            var existingProduct = await _repository.GetByIdAsync(request.ProductDto.Id);

            if (existingProduct == null)
            {
                return ApiResponse<ProductDto>.Fail("Продукт не найден");
            }

            // Обновляем поля
            existingProduct.Name = request.ProductDto.Name;
            existingProduct.Description = request.ProductDto.Description;
            existingProduct.Price = request.ProductDto.Price;
            existingProduct.ImageUrl = request.ProductDto.ImageUrl;

            await _repository.UpdateAsync(existingProduct);

            // Собираем обратно DTO
            var updatedDto = new ProductDto
            {
                Id = existingProduct.Id,
                Name = existingProduct.Name,
                Description = existingProduct.Description,
                Price = existingProduct.Price,
                ImageUrl = existingProduct.ImageUrl
            };

            return ApiResponse<ProductDto>.Ok(updatedDto);
        }
    }

}
