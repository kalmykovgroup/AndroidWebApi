using Api.Contracts.Commands;
using Api.Contracts.Dtos;
using Api.Interfaces;
using Api.Models;
using MediatR;

namespace Api.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, OrderDto>
    {
        private readonly IOrderRepository _repository;

        public CreateOrderHandler(IOrderRepository repository) => _repository = repository;

        public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                CustomerName = request.CustomerName,
                Items = request.Items.Select(i => new OrderItem
                {
                    ProductName = i.ProductName,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                }).ToList()
            };

            var saved = await _repository.CreateAsync(order);

            return new OrderDto
            {
                Id = saved.Id,
                CreatedAt = saved.CreatedAt,
                CustomerName = saved.CustomerName,
                Items = saved.Items.Select(i => new OrderItemDto
                {
                    ProductName = i.ProductName,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    TotalPrice = i.TotalPrice
                }).ToList(),
                TotalAmount = saved.TotalAmount
            };
        }
    }
}
