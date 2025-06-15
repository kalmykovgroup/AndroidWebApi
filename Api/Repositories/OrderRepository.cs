using Api.Interfaces;
using Api.Models;

namespace Api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new();

        public OrderRepository()
        {
            _orders.Add(new Order
            {
                CustomerName = "Иван Иванов",
                Status = OrderStatus.Pending,
                Items = new List<OrderItem>
                {
                    new() { ProductName = "Ноутбук", Quantity = 1, UnitPrice = 75000 },
                    new() { ProductName = "Мышь", Quantity = 2, UnitPrice = 1500 }
                }
            });
        }

        public Task<List<Order>> GetAllAsync() => Task.FromResult(_orders);

        public Task<Order?> GetByIdAsync(Guid id) => Task.FromResult(_orders.FirstOrDefault(o => o.Id == id));

        public Task<bool> UpdateAsync(Order order)
        {
            var index = _orders.FindIndex(o => o.Id == order.Id);
            if (index < 0) return Task.FromResult(false);
            _orders[index] = order;
            return Task.FromResult(true);
        }
    }
}
