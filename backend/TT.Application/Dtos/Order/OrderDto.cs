namespace TT.Application.Dtos.Order
{
    public class OrderCreateDto
    {
        public int ClientId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetailDto> Details { get; set; } = new();
    }

    public class OrderDetailDto
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderUpdateDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetailDto> Details { get; set; } = new();
    }


}
