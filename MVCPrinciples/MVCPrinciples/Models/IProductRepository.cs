namespace MVCPrinciples.Models
{
    public interface IProductRepository
    {
        public IEnumerable<Product> LimitedProducts(int numberOfProducts);

        public void Add(Product product);

        public void Edit(Product product);

        public Product GetProductById(int productId);
    }
}
