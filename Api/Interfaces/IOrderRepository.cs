using Api.Models;

namespace Api.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(Order order);
    }
}
