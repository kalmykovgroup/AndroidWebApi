using Api.Contracts.Dtos;

namespace Api.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(Guid id);
        Task<ProductDto> AddAsync(ProductDto product);
        Task<ProductDto> UpdateAsync(ProductDto product);
        Task<bool> DeleteAsync(Guid id);
    }
}
