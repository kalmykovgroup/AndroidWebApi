using Api.Contracts.Dtos;
using Api.Interfaces;

namespace Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<ProductDto> _products = new()
        {
            new ProductDto { Id = Guid.NewGuid(), Name = "Phone", Price = 599.99m, Description = "Smartphone with 6GB RAM", ImageUrl = "product/phone.webp" },
            new ProductDto { Id = Guid.NewGuid(), Name = "Laptop", Price = 999.99m, Description = "Laptop with 16GB RAM and SSD", ImageUrl = "product/laptop.webp" },
            new ProductDto { Id = Guid.NewGuid(), Name = "Tablet", Price = 299.99m, Description = "10-inch tablet with 64GB storage", ImageUrl = "product/tablet.webp" },
            new ProductDto { Id = Guid.NewGuid(), Name = "Smartwatch", Price = 199.99m, Description = "Waterproof smartwatch with heart rate monitor", ImageUrl = "product/smartwatch.webp" },
            new ProductDto { Id = Guid.NewGuid(), Name = "Bluetooth Headphones", Price = 149.99m, Description = "Noise-cancelling Bluetooth headphones", ImageUrl = "product/headphones.webp" },
            new ProductDto { Id = Guid.NewGuid(), Name = "Wireless Mouse", Price = 49.99m, Description = "Ergonomic wireless mouse", ImageUrl = "product/mouse.webp" },
            new ProductDto { Id = Guid.NewGuid(), Name = "Mechanical Keyboard", Price = 129.99m, Description = "Mechanical keyboard with RGB lighting", ImageUrl = "product/keyboard.webp" },
            new ProductDto { Id = Guid.NewGuid(), Name = "4K Monitor", Price = 399.99m, Description = "27-inch 4K UHD monitor", ImageUrl = "product/monitor.webp" },
            new ProductDto { Id = Guid.NewGuid(), Name = "External SSD", Price = 179.99m, Description = "1TB USB-C external SSD", ImageUrl = "product/ssd.webp" },
            new ProductDto { Id = Guid.NewGuid(), Name = "Webcam", Price = 89.99m, Description = "1080p HD webcam with microphone", ImageUrl = "product/webcam.webp" },
            new ProductDto { Id = Guid.NewGuid(), Name = "Gaming Chair", Price = 299.99m, Description = "Ergonomic gaming chair with lumbar support", ImageUrl = "product/chair.webp" },
            new ProductDto { Id = Guid.NewGuid(), Name = "Graphics Tablet", Price = 249.99m, Description = "Graphics tablet with pen pressure sensitivity", ImageUrl = "product/tablet_graphics.webp" },
            new ProductDto { Id = Guid.NewGuid(), Name = "Smart Speaker", Price = 129.99m, Description = "Smart speaker with voice assistant", ImageUrl = "product/speaker.webp" },
            new ProductDto { Id = Guid.NewGuid(), Name = "Portable Charger", Price = 59.99m, Description = "20,000mAh portable charger", ImageUrl = "product/charger.webp" },
            new ProductDto { Id = Guid.NewGuid(), Name = "Drone", Price = 799.99m, Description = "Drone with 4K camera and GPS", ImageUrl = "product/drone.webp" },
            new ProductDto { Id = Guid.NewGuid(), Name = "Action Camera", Price = 249.99m, Description = "4K action camera with waterproof case", ImageUrl = "product/action_camera.webp" },
            new ProductDto { Id = Guid.NewGuid(), Name = "Smart Light Bulb", Price = 39.99m, Description = "Smart LED light bulb with app control", ImageUrl = "product/bulb.webp" }
        };



         
        public Task<List<ProductDto>> GetAllAsync()
        {
            return Task.FromResult(_products.ToList());
        }

        public Task<ProductDto?> GetByIdAsync(Guid id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(product);
        }

        public Task<ProductDto> AddAsync(ProductDto product)
        {
            product.Id = Guid.NewGuid();
            _products.Add(product);
            return Task.FromResult(product);
        }

        public Task<ProductDto> UpdateAsync(ProductDto product)
        {
            var index = _products.FindIndex(p => p.Id == product.Id);
            if (index >= 0)
            {
                _products[index] = product; // Полная замена объекта в списке
            }
            return Task.FromResult(product);
        }



        public Task<bool> DeleteAsync(Guid id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return Task.FromResult(false);

            _products.Remove(product);
            return Task.FromResult(true);
        }
    }

}
