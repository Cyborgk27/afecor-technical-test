using TT.Domain.Commons;

namespace TT.Domain.Entities
{
    public class OrderDetail : BaseEntity<int>
    {
        public int OrderId { get; private set; }
        public int ProductId { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public decimal SubTotal { get; private set; }

        private OrderDetail() { } 

        public OrderDetail(int orderId, int productId, decimal price, int quantity)
        {
            if (productId <= 0) throw new ArgumentException("ProductId must be valid");
            if (price <= 0) throw new ArgumentException("Price must be greater than zero");
            if (quantity <= 0) throw new ArgumentException("Quantity must be greater than zero");

            OrderId = orderId;
            ProductId = productId;
            Price = price;
            Quantity = quantity;
            SubTotal = price * quantity;
        }
    }
}
