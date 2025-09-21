using TT.Domain.Commons;

namespace TT.Domain.Entities
{
    public class Order : BaseEntity<int>
    {
        public DateTime OrderDate { get; private set; }
        public int ClientId { get; private set; }
        public decimal Total { get; private set; }

        public List<OrderDetail> Details { get; private set; } = new();

        private Order() { }

        public Order(int clientId, DateTime orderDate)
        {
            if (clientId <= 0)
                throw new ArgumentException("ClientId must be valid");

            ClientId = clientId;
            OrderDate = orderDate;
            Total = 0;
        }

        public void AddDetail(int productId, decimal price, int quantity)
        {
            var detail = new OrderDetail(Id, productId, price, quantity);
            Details.Add(detail);

            RecalculateTotal();
        }

        private void RecalculateTotal()
        {
            Total = Details.Sum(d => d.SubTotal);
        }
    }
}
