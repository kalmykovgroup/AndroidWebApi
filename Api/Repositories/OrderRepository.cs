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
                Status = OrderStatus.NEW,
                Items = new List<OrderItem>
            {
                new() { ProductName = "Ноутбук", Quantity = 1, UnitPrice = 75000 },
                new() { ProductName = "Мышь", Quantity = 2, UnitPrice = 1500 }
            }
            });

            _orders.Add(new Order
            {
                CustomerName = "Мария Петрова",
                Status = OrderStatus.PROCESSING,
                Items = new List<OrderItem>
            {
                new() { ProductName = "Смартфон", Quantity = 1, UnitPrice = 45000 },
                new() { ProductName = "Чехол", Quantity = 1, UnitPrice = 1500 }
            }
            });

            _orders.Add(new Order
            {
                CustomerName = "Алексей Смирнов",
                Status = OrderStatus.SHIPPED,
                Items = new List<OrderItem>
            {
                new() { ProductName = "Планшет", Quantity = 1, UnitPrice = 32000 },
                new() { ProductName = "Стилус", Quantity = 1, UnitPrice = 2000 }
            }
            });

            _orders.Add(new Order
            {
                CustomerName = "Ольга Соколова",
                Status = OrderStatus.DELIVERED,
                Items = new List<OrderItem>
            {
                new() { ProductName = "Монитор", Quantity = 1, UnitPrice = 21000 }
            }
            });

            _orders.Add(new Order
            {
                CustomerName = "Сергей Кузнецов",
                Status = OrderStatus.CANCELLED,
                Items = new List<OrderItem>
            {
                new() { ProductName = "Наушники", Quantity = 1, UnitPrice = 8000 }
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
