using Api.Contracts;
using Api.Contracts.Dtos;
using Api.Contracts.Queries;
using Api.Interfaces;
using MediatR;

namespace Api.Handlers.Orders
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, ApiResponse<List<OrderDto>>>
    {
        private readonly IOrderRepository _repository;

        public GetAllOrdersHandler(IOrderRepository repository) => _repository = repository;

        public async Task<ApiResponse<List<OrderDto>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _repository.GetAllAsync();

            var result = orders.Select(o => new OrderDto
            {
                Id = o.Id,
                CreatedAt = o.CreatedAt,
                CustomerName = o.CustomerName,
                Status = o.Status,
                TotalAmount = o.TotalAmount,
                Items = o.Items.Select(i => new OrderItemDto
                {
                    ProductName = i.ProductName,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    TotalPrice = i.TotalPrice
                }).ToList()
            }).ToList();

            return ApiResponse<List<OrderDto>>.Ok(result);
        }
    }
}
