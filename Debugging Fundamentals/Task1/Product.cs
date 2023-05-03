namespace Task1
{
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Product return false.
            Product product = obj as Product;
            if ((System.Object)product == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (Name == product.Name) && (Price == product.Price);

        }

        public bool Equals(Product product)
        {
            // If parameter is null return false:
            if ((object)product == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (Name == product.Name) && (Price == product.Price);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
