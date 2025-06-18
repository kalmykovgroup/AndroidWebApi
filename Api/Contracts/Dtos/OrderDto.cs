namespace Api.Contracts.Dtos
{

    public enum OrderStatus
    {
        NEW,
        PROCESSING,
        SHIPPED,
        DELIVERED,
        CANCELLED
    }

    public class OrderDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public List<OrderItemDto> Items { get; set; } = new();
        public decimal TotalAmount { get; set; }
        public OrderStatus OrderStatus { get; set; }  
    }

}
