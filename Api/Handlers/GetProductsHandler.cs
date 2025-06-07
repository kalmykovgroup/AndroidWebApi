using Api.Contracts;
using Api.Contracts.Dtos;
using Api.Contracts.Queries;
using Api.Interfaces;
using MediatR;

namespace Api.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, ApiResponse<List<ProductDto>>>
    {
        private readonly IProductRepository _repository;

        public GetProductsHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<List<ProductDto>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
           var result = await _repository.GetAllAsync();

           return ApiResponse<List<ProductDto>>.Ok(result);
        }
    }
}
