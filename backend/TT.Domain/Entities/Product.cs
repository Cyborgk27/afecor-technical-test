using TT.Domain.Commons;

namespace TT.Domain.Entities
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public decimal Price { get; set; }

        private Product() { }

        public Product(string name, decimal cost, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name is required");

            if (cost < 0)
                throw new ArgumentException("Cost cannot be negative");

            if (price < cost)
                throw new ArgumentException("Price cannot be less than cost");

            Name = name;
            Cost = cost;
            Price = price;
        }
    }
}
