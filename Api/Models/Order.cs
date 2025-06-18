namespace Api.Models
{
    

    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string CustomerName { get; set; } = string.Empty;
        public List<OrderItem> Items { get; set; } = new();
        public OrderStatus Status { get; set; } = OrderStatus.NEW;

        public decimal TotalAmount => Items.Sum(i => i.TotalPrice);
    }
}
