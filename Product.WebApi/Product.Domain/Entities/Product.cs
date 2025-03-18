using Product.Domain.Common;

namespace Product.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; } = 0;

        private Product()
        {
            Name = string.Empty;
            Description = string.Empty;
        }

        private Product(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public static Product Create(string name, string description, decimal price)
        {
            ValidateInputs(name, description, price);
            return new Product(name, description, price);
        }

        public void Update(string name, string description, decimal price)
        {
            ValidateInputs(name, description, price);

            Name = name;
            Description = Description;
            Price = price;
            UpdatedDate = DateTime.Now;
        }

        private static void ValidateInputs(string name, string description, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name cannot be null or empty.", nameof(name));

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Genre cannot be null or empty.", nameof(description));

            if (price < 0)
                throw new ArgumentException("Price must be greater 0 ", nameof(price));
        }
    }
}
